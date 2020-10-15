using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp36
{
    public class SerialHelper : SerialPort
    {
        private int timerOut;
        public SerialHelper(string portName, int baudRate, int TimerOut, string InstanceName)
        {
            try
            {
                PortName = portName;
                BaudRate = baudRate;
                TimerOut = timerOut;
                DataBits = 8;
                StopBits = StopBits.One;
                Handshake = Handshake.None;
                //DataBits = 8;
                Open();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

        }
        public async Task SenAsync(byte[] Data)
        {
            await BaseStream.WriteAsync(Data, 0, Data.Length);
            BaseStream.Flush();
            Thread.Sleep(30);
        }
        public byte CSUM(List<byte> DATA)
        {
            byte KQ = 0X00;
            for (int i = 0; i < DATA.Count; i++)
            {
                KQ += DATA[i];
            }
            return KQ;
        }
        byte[] Buffe = new byte[32];
        byte[] Reciver;
        SemaphoreSlim LOCK = new SemaphoreSlim(1, 1);
        public async Task<byte[]> ReadGPIO()
        {
            try
            {
                await LOCK.WaitAsync();
                List<byte> DATA = new List<byte>() { (byte)'T' };
                DATA.Add(CSUM(DATA));
                // DATA.Insert(0, SlaveID);
                await SenAsync(DATA.ToArray());
                if (IsOpen)
                {
                    var ReciverTask = BaseStream.ReadAsync(Buffe, 0, Buffe.Length);
                    var KQ = (await Task.WhenAny(ReciverTask, Task.Delay(100))) == ReciverTask;
                    if (KQ)
                    {
                        int Count = ReciverTask.Result;
                        if (Count > 4)
                        {
                            Reciver = new byte[Count];
                            Array.Copy(Buffe, 0, Reciver, 0, Count);
                            List<byte> NHAN = Reciver.ToList();
                            NHAN.RemoveAt(NHAN.Count - 1);
                            if (CSUM(NHAN) == Reciver[Reciver.Length - 1])
                                return NHAN.ToArray();

                        }

                    }
                }
                return null;

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                LOCK.Release();
                DiscardInBuffer();
            }
        }
        public async Task WiteGPIO(byte[] DATA)
        {
            try
            {
                await LOCK.WaitAsync();
                List<byte> Fram = new List<byte>() { (byte)'C' };
                Fram.AddRange(DATA);
                Fram.Add(CSUM(Fram));
                //Fram.Insert(0, SlaveID);
                await SenAsync(Fram.ToArray());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                LOCK.Release();
                DiscardOutBuffer();
            }

        }
    }
    public class GPIO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string GPIODescription { get; set; }
        public string GPIOLabel { get; set; }
        public UInt64 GPIOBitmask { get; set; }
        public PinValue _PinValue;
        public PinValue PinValue
        {
            get { return _PinValue; }
            set
            {
                if (_PinValue != value)
                {
                    _PinValue = value;
                    NotifyPropertyChanged("PinValue");
                    if (value == PinValue.ON)
                        NotifyPinValueChanged(Edge.Rise);
                    else
                        NotifyPinValueChanged(Edge.Fall);
                }
            }
        }
        private void NotifyPinValueChanged(Edge e)
        {
            // Make sure someone is listening to event
            onPinValueChanged?.Invoke(this, new PinValueChangedEventArgs(e));
        }
        private object _eventLock = new object();
        public delegate void PinValueChanged(object sender, PinValueChangedEventArgs e);
        public event PinValueChanged OnPinValueChanged
        {
            add
            {
                lock (_eventLock)
                {
                    onPinValueChanged -= value;
                    onPinValueChanged += value;
                }
            }
            remove
            {
                lock (_eventLock)
                    onPinValueChanged -= value;
            }
        }
        private event PinValueChanged onPinValueChanged;
        public class PinValueChangedEventArgs : EventArgs
        {
            public Edge Edge { get; private set; }
            public PinValueChangedEventArgs(Edge e)
            {
                Edge = e;
            }
        }
        public enum Edge { Rise, Fall }
    }
    public class OutPutPin : GPIO
    {
        public byte SlaverID { get; set; }
        public async Task SET()
        {
            var NHAN = await App.MAIN.ReadGPIO();
            if (NHAN != null)
            {
                UInt64 RESITER = BitConverter.ToUInt32(NHAN, 4);
                RESITER |= GPIOBitmask;
                byte[] Fram = BitConverter.GetBytes(RESITER);
                await App.MAIN.WiteGPIO(Fram);
            }
        }
        public async Task RESET()
        {
            var NHAN = await App.MAIN.ReadGPIO();
            if (NHAN != null)
            {
                UInt64 RESITER = BitConverter.ToUInt32(NHAN, 4);
                RESITER &= ~GPIOBitmask;
                byte[] Fram = BitConverter.GetBytes(RESITER);
                await App.MAIN.WiteGPIO(Fram);
            }
        }
    }
    public class MainFoodStatus : INotifyPropertyChanged
    {
        public byte SlaveID { get; set; }
        public string MainName { get; set; }
        public UInt32 _InPutResister;
        public UInt32 InPutResister
        {
            get { return _InPutResister; }
            set
            {
                if (_InPutResister != value)
                {
                    _InPutResister = value;
                    NotifyPropertyChanged("InPutResister");
                }
            }
        }
        public UInt32 _OutPutResister;
        public UInt32 OutPutResister
        {
            get { return _OutPutResister; }
            set
            {
                if (_OutPutResister != value)
                {
                    _OutPutResister = value;
                    NotifyPropertyChanged("OutPutResister");
                }
            }
        }
        public ObservableCollection<GPIO> InputPins { get; set; }
        public ObservableCollection<OutPutPin> OutPutPin { get; set; }
        public async Task GetIO()
        {
            try
            {
                var NHAN = await App.MAIN.ReadGPIO();
                if (NHAN != null)
                {
                    InPutResister = BitConverter.ToUInt32(NHAN, 0);
                    OutPutResister = BitConverter.ToUInt32(NHAN, 4);
                    foreach (GPIO GP in InputPins)
                    {
                        if ((InPutResister & GP.GPIOBitmask) > 0)
                        {
                            GP.PinValue = PinValue.ON;
                        }
                        else
                            GP.PinValue = PinValue.OFF;
                    }
                    foreach (OutPutPin GP in OutPutPin)
                    {
                        if ((OutPutResister & GP.GPIOBitmask) > 0)
                        {
                            GP.PinValue = PinValue.ON;
                        }
                        else
                            GP.PinValue = PinValue.OFF;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    public class Main
    {
        public static MainFoodStatus F1 = new MainFoodStatus()
        {
            SlaveID = 0X01,
            MainName = "MAIN_F1",
            InputPins = new ObservableCollection<GPIO>()
                {
                    new GPIO(){GPIODescription="INF1_00",GPIOLabel="PC6",GPIOBitmask=BITMASK.IN0},
                    new GPIO(){GPIODescription="INF1_01",GPIOLabel="PC7",GPIOBitmask=BITMASK.IN1},
                    new GPIO(){GPIODescription="INF1_02",GPIOLabel="PC8",GPIOBitmask=BITMASK.IN2},
                    new GPIO(){GPIODescription="INF1_03",GPIOLabel="PC9",GPIOBitmask=BITMASK.IN3},
                    new GPIO(){GPIODescription="INF1_04",GPIOLabel="PA8",GPIOBitmask=BITMASK.IN4},
                    new GPIO(){GPIODescription="INF1_05",GPIOLabel="PA9",GPIOBitmask=BITMASK.IN5},
                    new GPIO(){GPIODescription="INF1_06",GPIOLabel="PA10",GPIOBitmask=BITMASK.IN6},
                    new GPIO(){GPIODescription="INF1_07",GPIOLabel="PA13",GPIOBitmask=BITMASK.IN7},
                    new GPIO(){GPIODescription="INF1_08",GPIOLabel="PA14",GPIOBitmask=BITMASK.IN8},
                    new GPIO(){GPIODescription="INF1_09",GPIOLabel="PA15",GPIOBitmask=BITMASK.IN9},
                    new GPIO(){GPIODescription="INF1_10",GPIOLabel="PC10",GPIOBitmask=BITMASK.IN10},
                    new GPIO(){GPIODescription="INF1_11",GPIOLabel="PC11",GPIOBitmask=BITMASK.IN11},
                    new GPIO(){GPIODescription="INF1_12",GPIOLabel="PC12",GPIOBitmask=BITMASK.IN12},
                    new GPIO(){GPIODescription="INF1_13",GPIOLabel="PD0",GPIOBitmask=BITMASK.IN13},
                    new GPIO(){GPIODescription="INF1_14",GPIOLabel="PD1",GPIOBitmask=BITMASK.IN14},
                    new GPIO(){GPIODescription="INF1_15",GPIOLabel="PD2",GPIOBitmask=BITMASK.IN15},
                    new GPIO(){GPIODescription="INF1_16",GPIOLabel="PD3",GPIOBitmask=BITMASK.IN16},
                    new GPIO(){GPIODescription="INF1_17",GPIOLabel="PD4",GPIOBitmask=BITMASK.IN17},
                    new GPIO(){GPIODescription="INF1_18",GPIOLabel="PD5",GPIOBitmask=BITMASK.IN18},
                    new GPIO(){GPIODescription="INF1_19",GPIOLabel="PD6",GPIOBitmask=BITMASK.IN19},
                    new GPIO(){GPIODescription="INF1_20",GPIOLabel="PD7",GPIOBitmask=BITMASK.IN20},
                    new GPIO(){GPIODescription="INF1_21",GPIOLabel="PB3",GPIOBitmask=BITMASK.IN21},
                    new GPIO(){GPIODescription="INF1_22",GPIOLabel="PB4",GPIOBitmask=BITMASK.IN22},
                    new GPIO(){GPIODescription="INF1_23",GPIOLabel="PB5",GPIOBitmask=BITMASK.IN23},
                    new GPIO(){GPIODescription="INF1_24",GPIOLabel="PB6",GPIOBitmask=BITMASK.IN24},
                    new GPIO(){GPIODescription="INF1_25",GPIOLabel="PB7",GPIOBitmask=BITMASK.IN25},
                    new GPIO(){GPIODescription="INF1_26",GPIOLabel="PB8",GPIOBitmask=BITMASK.IN26},
                    new GPIO(){GPIODescription="INF1_27",GPIOLabel="PB9",GPIOBitmask=BITMASK.IN27},
                    new GPIO(){GPIODescription="INF1_28",GPIOLabel="PE0",GPIOBitmask=BITMASK.IN28},
                    new GPIO(){GPIODescription="INF1_29",GPIOLabel="PE1",GPIOBitmask=BITMASK.IN29},
                    new GPIO(){GPIODescription="INF1_30",GPIOLabel="PE2",GPIOBitmask=BITMASK.IN30},
                    new GPIO(){GPIODescription="INF1_31",GPIOLabel="PE3",GPIOBitmask=BITMASK.IN31},
                    // new GPIO(){GPIODescription="INF1_32",GPIOLabel="PE4",GPIOBitmask=BITMASK.IN32},
                    //new GPIO(){GPIODescription="INF1_33",GPIOLabel="PE5",GPIOBitmask=BITMASK.IN33},
                    //new GPIO(){GPIODescription="INF1_34",GPIOLabel="PE6",GPIOBitmask=BITMASK.IN34},
                    //new GPIO(){GPIODescription="INF1_35",GPIOLabel="PC13",GPIOBitmask=BITMASK.IN35},
                    //new GPIO(){GPIODescription="INF1_36",GPIOLabel="PC14",GPIOBitmask=BITMASK.IN36},
                    //new GPIO(){GPIODescription="INF1_37",GPIOLabel="PC15",GPIOBitmask=BITMASK.IN37},



                },
            OutPutPin = new ObservableCollection<OutPutPin>()
                {
                    new OutPutPin(){GPIODescription="OUTF1_00",GPIOLabel="PC0",GPIOBitmask=BITMASK.IN0,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_01",GPIOLabel="PC1",GPIOBitmask=BITMASK.IN1,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_02",GPIOLabel="PC2",GPIOBitmask=BITMASK.IN2,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_03",GPIOLabel="PC3",GPIOBitmask=BITMASK.IN3,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_04",GPIOLabel="PA0",GPIOBitmask=BITMASK.IN4,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_05",GPIOLabel="PA1",GPIOBitmask=BITMASK.IN5,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_06",GPIOLabel="PA4",GPIOBitmask=BITMASK.IN6,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_07",GPIOLabel="PA5",GPIOBitmask=BITMASK.IN7,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_08",GPIOLabel="PA6",GPIOBitmask=BITMASK.IN8,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_09",GPIOLabel="PA7",GPIOBitmask=BITMASK.IN9,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_10",GPIOLabel="PC4",GPIOBitmask=BITMASK.IN10,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_11",GPIOLabel="PC5",GPIOBitmask=BITMASK.IN11,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_12",GPIOLabel="PB0",GPIOBitmask=BITMASK.IN12,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_13",GPIOLabel="PB1",GPIOBitmask=BITMASK.IN13,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_14",GPIOLabel="PB2",GPIOBitmask=BITMASK.IN14,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_15",GPIOLabel="PE7",GPIOBitmask=BITMASK.IN15,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_16",GPIOLabel="PE8",GPIOBitmask=BITMASK.IN16,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_17",GPIOLabel="PE9",GPIOBitmask=BITMASK.IN17,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_18",GPIOLabel="PE10",GPIOBitmask=BITMASK.IN18,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_19",GPIOLabel="PE11",GPIOBitmask=BITMASK.IN19,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_20",GPIOLabel="PE12",GPIOBitmask=BITMASK.IN20,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_21",GPIOLabel="PE13",GPIOBitmask=BITMASK.IN21,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_22",GPIOLabel="PE14",GPIOBitmask=BITMASK.IN22,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_23",GPIOLabel="PE15",GPIOBitmask=BITMASK.IN23,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_24",GPIOLabel="PB10",GPIOBitmask=BITMASK.IN24,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_25",GPIOLabel="PB11",GPIOBitmask=BITMASK.IN25,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_26",GPIOLabel="PB12",GPIOBitmask=BITMASK.IN26,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_27",GPIOLabel="PB13",GPIOBitmask=BITMASK.IN27,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_28",GPIOLabel="PB14",GPIOBitmask=BITMASK.IN28,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_29",GPIOLabel="PB15",GPIOBitmask=BITMASK.IN29,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_30",GPIOLabel="PD8",GPIOBitmask=BITMASK.IN30,SlaverID=0X00},
                    new OutPutPin(){GPIODescription="OUTF1_31",GPIOLabel="PD9",GPIOBitmask=BITMASK.IN31,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_32",GPIOLabel="PD10",GPIOBitmask=BITMASK.IN32,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_33",GPIOLabel="PD11",GPIOBitmask=BITMASK.IN33,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_34",GPIOLabel="PD12",GPIOBitmask=BITMASK.IN34,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_35",GPIOLabel="PD13",GPIOBitmask=BITMASK.IN35,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_36",GPIOLabel="PD14",GPIOBitmask=BITMASK.IN36,SlaverID=0X00},
                    //new OutPutPin(){GPIODescription="OUTF1_37",GPIOLabel="PD15",GPIOBitmask=BITMASK.IN37,SlaverID=0X00},


                 }

        };
    }
    public enum PinValue { OFF, ON };
}

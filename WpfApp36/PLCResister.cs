using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp36
{
    public class PLCResister : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public string Word { get; set; }
        public short _WordValue;
        public short WordValue
        {
            get { return _WordValue; }
            set
            {
                if (_WordValue != value)
                {
                    _WordValue = value;
                    Bit0.BitValue = (value & 1 << 0) > 0 ? true : false;
                    Bit1.BitValue = (value & 1 << 1) > 0 ? true : false;
                    Bit2.BitValue = (value & 1 << 2) > 0 ? true : false;
                    Bit3.BitValue = (value & 1 << 3) > 0 ? true : false;
                    Bit4.BitValue = (value & 1 << 4) > 0 ? true : false;
                    Bit5.BitValue = (value & 1 << 5) > 0 ? true : false;
                    Bit6.BitValue = (value & 1 << 6) > 0 ? true : false;
                    Bit7.BitValue = (value & 1 << 7) > 0 ? true : false;
                    Bit8.BitValue = (value & 1 << 8) > 0 ? true : false;
                    Bit9.BitValue = (value & 1 << 9) > 0 ? true : false;
                    BitA.BitValue = (value & 1 << 10) > 0 ? true : false;
                    BitB.BitValue = (value & 1 << 11) > 0 ? true : false;
                    BitC.BitValue = (value & 1 << 12) > 0 ? true : false;
                    BitD.BitValue = (value & 1 << 13) > 0 ? true : false;
                    BitE.BitValue = (value & 1 << 14) > 0 ? true : false;
                    BitF.BitValue = (value & 1 << 15) > 0 ? true : false;
                }
                NotifyPropertyChanged("WordValue");
            }
        }
        public PLCBit Bit0 { get; set; }
        public PLCBit Bit1 { get; set; }
        public PLCBit Bit2 { get; set; }
        public PLCBit Bit3 { get; set; }
        public PLCBit Bit4 { get; set; }
        public PLCBit Bit5 { get; set; }
        public PLCBit Bit6 { get; set; }
        public PLCBit Bit7 { get; set; }
        public PLCBit Bit8 { get; set; }
        public PLCBit Bit9 { get; set; }
        public PLCBit BitA { get; set; }
        public PLCBit BitB { get; set; }
        public PLCBit BitC { get; set; }
        public PLCBit BitD { get; set; }
        public PLCBit BitE { get; set; }
        public PLCBit BitF { get; set; }
        public PLCResister(string Word)
        {
            this.Word = Word;
            Bit0 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "0" };
            Bit1 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "1" };
            Bit2 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "2" };
            Bit3 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "3" };
            Bit4 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "4" };
            Bit5 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "5" };
            Bit6 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "6" };
            Bit7 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "7" };
            Bit8 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "8" };
            Bit9 = new PLCBit() { BitAdress = Word.Replace("W", "X") + "9" };
            BitA = new PLCBit() { BitAdress = Word.Replace("W", "X") + "A" };
            BitB = new PLCBit() { BitAdress = Word.Replace("W", "X") + "B" };
            BitC = new PLCBit() { BitAdress = Word.Replace("W", "X") + "C" };
            BitD = new PLCBit() { BitAdress = Word.Replace("W", "X") + "D" };
            BitE = new PLCBit() { BitAdress = Word.Replace("W", "X") + "E" };
            BitF = new PLCBit() { BitAdress = Word.Replace("W", "X") + "F" };
        }
        //public class PLCButton : PLCBit
        //{
        //    public PLCBit ButtonAdress { get; set; }
        //    public PLCBit ButtonLamp { get; set; }
        //    public PLCBit ButtonRedy { get; set; }
        //}

        public class PLCBit : INotifyPropertyChanged
        {
            public string BitAdress { get; set; }
            public bool _BitValue;
            public bool BitValue
            {
                get { return _BitValue; }
                set
                {
                    if (_BitValue != value)
                    {
                        _BitValue = value;
                        NotifyPropertyChanged("BitValue");
                        if (value == true)
                            NotifyPinValueChanged(Edge.Rise);
                        else
                            NotifyPinValueChanged(Edge.Fall);
                    }
                }
            }
            public bool _JigStatus = true;
            public bool JigStatus
            {
                get { return _JigStatus; }
                set
                {
                    if (_JigStatus != value)
                    {
                        _JigStatus = value;
                        NotifyPropertyChanged("JigStatus");
                    }
                }
            }
            SemaphoreSlim BitLock = new SemaphoreSlim(1, 1);
            public async Task SET()
            {
                try
                {
                    await BitLock.WaitAsync();
                   // await App.Serial.WriteBitAsync(BitAdress, 01);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    BitLock.Release();
                }
            }
            public async Task RST()
            {
                try
                {
                    await BitLock.WaitAsync();
                    //await App.Serial.WriteBitAsync(BitAdress, 00);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    BitLock.Release();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void NotifyPropertyChanged(string PropertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
            //public enum JIGUSE { USE, NOTUSE };
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
    }
}

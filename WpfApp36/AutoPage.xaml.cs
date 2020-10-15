using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp36
{
    /// <summary>
    /// Interaction logic for AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public static LowLevelKeyboardListener _listener;
        public static TextBox AutoButton;
        public AutoPage()
        {
            InitializeComponent();
            Loaded += AutoPage_Loaded;
            AutoButton = TbAuto;
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();
        }
        public string s = null;
        private async void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (e.KeyPressed != Key.Return)
            {
                s = KeycodeToChar(e.KeyPressed);
                TbAuto.Text += s;
                if (TbAuto.Text == App.ModelMain.ModelName)
                {
                    if (chbSpecical.IsChecked == false)
                    {
                        if ((Thistime >= Data[0].From && Thistime <= Data[0].To) || (Thistime >= Data[5].From && Thistime <= Data[5].To))
                        {
                            LineABC[0].SanLuongThucTe++;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[1].From && Thistime <= Data[1].To) || (Thistime >= Data[6].From && Thistime <= Data[6].To))
                        {
                            LineABC[1].SanLuongThucTe++;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[2].From && Thistime <= Data[2].To) || (Thistime >= Data[7].From && Thistime <= Data[7].To))
                        {
                            LineABC[2].SanLuongThucTe++;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[3].From && Thistime <= Data[3].To) || (Thistime >= Data[8].From && Thistime <= Data[8].To))
                        {
                            LineABC[3].SanLuongThucTe++;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[4].From && Thistime <= Data[4].To && App.ModelMain.SumTime == 5) || (Thistime >= Data[9].From && Thistime <= Data[9].To && App.ModelMain.SumTime == 5))
                        {
                            LineABC[4].SanLuongThucTe++;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                    }
                    else
                    {
                        if ((Thistime >= Data[0].From && Thistime <= Data[0].To) || (Thistime >= Data[5].From && Thistime <= Data[5].To))
                        {
                            LineABC[0].SanLuongThucTe += 50;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[1].From && Thistime <= Data[1].To) || (Thistime >= Data[6].From && Thistime <= Data[6].To))
                        {
                            LineABC[1].SanLuongThucTe += 50;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[2].From && Thistime <= Data[2].To) || (Thistime >= Data[7].From && Thistime <= Data[7].To))
                        {
                            LineABC[2].SanLuongThucTe += 50;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[3].From && Thistime <= Data[3].To) || (Thistime >= Data[8].From && Thistime <= Data[8].To))
                        {
                            LineABC[3].SanLuongThucTe += 50;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                        if ((Thistime >= Data[4].From && Thistime <= Data[4].To && App.ModelMain.SumTime == 5) || (Thistime >= Data[9].From && Thistime <= Data[9].To && App.ModelMain.SumTime == 5))
                        {
                            LineABC[4].SanLuongThucTe += 50;
                            await Task.Delay(10);
                            TbAuto.Clear();
                        }
                    }
                }

            }
            else
            {
                await Task.Delay(10);
                TbAuto.Clear();
            }
        }

        public double AutoTimer = 0;
        public List<Period> Data = new List<Period>();
        public TimeSpan Thistime;
        public int Step = 0;
        public int Start = 0;
        public int Rise = 0;
        public TimeSpan Num;
        public static CancellationTokenSource MAINLOOP = null;
        public static CancellationTokenSource AUTOLOOP = null;
        public static List<LineStatus> LineStatusData;
        public static List<KeyValue> DataTarget;
        public static ObservableCollection<LineStatus> LineABC;
        private void Init()
        {
            LineABC = new ObservableCollection<LineStatus>();


            var _Line1 = LineStatusData.Where(x => x.LineName == "A-Time").FirstOrDefault();
            if (_Line1 != null)
            {
                LineABC.Add(_Line1);
            }
            var _Line2 = LineStatusData.Where(x => x.LineName == "B-Time").FirstOrDefault();
            if (_Line2 != null)
            {
                LineABC.Add(_Line2);
            }
            var _Line3 = LineStatusData.Where(x => x.LineName == "C-Time").FirstOrDefault();
            if (_Line3 != null)
            {
                LineABC.Add(_Line3);
            }
            var _Line4 = LineStatusData.Where(x => x.LineName == "D-Time").FirstOrDefault();
            if (_Line4 != null)
            {
                LineABC.Add(_Line4);
            }
            var _Line5 = LineStatusData.Where(x => x.LineName == "E-Time").FirstOrDefault();
            if (_Line5 != null && App.ModelMain.SumTime == 5)
            {
                LineABC.Add(_Line5);
            }
            var _Line6 = LineStatusData.Where(x => x.LineName == "AcTual").FirstOrDefault();
            if (_Line6 != null)
            {
                LineABC.Add(_Line6);
            }

            foreach (LineStatus Line in LineABC)
            {
                Line.PropertyChanged -= Line_PropertyChanged;
                Line.PropertyChanged += Line_PropertyChanged;
            }

            LvMain.ItemsSource = LineABC;
            DataContext = this;

        }

        private async void Line_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LineStatus Sender1 = sender as LineStatus;
            using (var Db = new SettingContect())
            {

                var ButtonClick = Db.LineStatuses.Where(x => x.LineId == Sender1.LineId).FirstOrDefault();
                if (ButtonClick != null)
                {
                    ButtonClick.SanLuongChenh = Sender1.SanLuongChenh;
                    ButtonClick.SanLuongThucTe = Sender1.SanLuongThucTe;
                    ButtonClick.SanLuongTuTao = Sender1.SanLuongTuTao;
                    await Db.SaveChangesAsync();
                }
            }
        }

        private void AutoPage_Loaded(object sender, RoutedEventArgs e)
        {
            Data.Add(new Period(App.ModelTimerMain.TimeAFrom, App.ModelTimerMain.TimeATo));
            Data.Add(new Period(App.ModelTimerMain.TimeBFrom, App.ModelTimerMain.TimeBTo));
            Data.Add(new Period(App.ModelTimerMain.TimeCFrom, App.ModelTimerMain.TimeCTo));
            Data.Add(new Period(App.ModelTimerMain.TimeDFrom, App.ModelTimerMain.TimeDTo));

            Data.Add(new Period(App.ModelTimerMain.TimeEFrom, App.ModelTimerMain.TimeETo));
            Data.Add(new Period(App.ModelTimerMain.TimeAFromNight, App.ModelTimerMain.TimeAToNight));
            Data.Add(new Period(App.ModelTimerMain.TimeBFromNight, App.ModelTimerMain.TimeBToNight));
            Data.Add(new Period(App.ModelTimerMain.TimeCFromNight, App.ModelTimerMain.TimeCToNight));
            Data.Add(new Period(App.ModelTimerMain.TimeDFromNight, App.ModelTimerMain.TimeDToNight));

            Data.Add(new Period(App.ModelTimerMain.TimeEFromNight, App.ModelTimerMain.TimeEToNight));
            Data.Add(new Period("19:59:56", "19:59:59"));
            Data.Add(new Period("7:59:56", "7:59:59"));
            DataInit.DataSeing();

            using (var Db = new SettingContect())
            {
                LineStatusData = Db.LineStatuses.ToList();

            }
            Init();

            if (MAINLOOP != null)
            {
                if (!MAINLOOP.IsCancellationRequested)
                {
                    MAINLOOP.Cancel();
                }
            }
            MAINLOOP = new CancellationTokenSource();
            Task.Run(async () => { await MAINLoopTask(MAINLOOP.Token); });
            if (AUTOLOOP != null)
            {
                if (!AUTOLOOP.IsCancellationRequested)
                {
                    AUTOLOOP.Cancel();
                }
            }
            AUTOLOOP = new CancellationTokenSource();
            Task.Run(async () => { await AUTOLoopTask(AUTOLOOP.Token); });

            TblLeader.Text = App.KeyValueMain.NameLeaDer;
            TblLine.Text = App.KeyValueMain.Key;
            TblWorker.Text = App.KeyValueMain.NhanLuc;
            TblModel.Text = App.ModelMain.ModelName;
            TblTarget.Text = App.ModelMain.Production.ToString("#,#", CultureInfo.InstalledUICulture);
            AutoTimer = (App.ModelMain.Production) * 100 / App.ModelMain.SumTime;
            AutoTimer = 7200000 / AutoTimer;
            AutoTimer = AutoTimer * 100;
            if (App.ModelMain.SumTime == 5)
            {
                LineABC[5].SanLuongTuTao = App.ModelMain.Production;
            }
            else LineABC[4].SanLuongTuTao = App.ModelMain.Production;


        }


        private Task AUTOLoopTask(CancellationToken token)
        {
            try
            {
                while (true)
                {

                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(20);
                    Thistime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss.ffff"));
                    LineABC[0].SanLuongChenh = LineABC[0].SanLuongThucTe - LineABC[0].SanLuongTuTao;
                    LineABC[1].SanLuongChenh = LineABC[1].SanLuongThucTe - LineABC[1].SanLuongTuTao;
                    LineABC[2].SanLuongChenh = LineABC[2].SanLuongThucTe - LineABC[2].SanLuongTuTao;
                    LineABC[3].SanLuongChenh = LineABC[3].SanLuongThucTe - LineABC[3].SanLuongTuTao;
                    LineABC[4].SanLuongChenh = LineABC[4].SanLuongThucTe - LineABC[4].SanLuongTuTao;
                    if (((Thistime >= Data[10].From && Thistime < Data[10].To) && App.ModelMain.SumTime == 4) || ((Thistime >= Data[11].From && Thistime < Data[11].To) && App.ModelMain.SumTime == 4))
                    {
                        LineABC[0].SanLuongTuTao = 0;
                        LineABC[0].SanLuongThucTe = 0;
                        LineABC[1].SanLuongTuTao = 0;
                        LineABC[1].SanLuongThucTe = 0;
                        LineABC[2].SanLuongTuTao = 0;
                        LineABC[2].SanLuongThucTe = 0;
                        LineABC[3].SanLuongTuTao = 0;
                        LineABC[3].SanLuongThucTe = 0;
                        LineABC[4].SanLuongThucTe = 0;

                    }
                    else if (((Thistime >= Data[10].From && Thistime < Data[10].To) && App.ModelMain.SumTime == 5) || ((Thistime >= Data[11].From && Thistime < Data[11].To) && App.ModelMain.SumTime == 5))
                    {
                        LineABC[0].SanLuongTuTao = 0;
                        LineABC[0].SanLuongThucTe = 0;
                        LineABC[1].SanLuongTuTao = 0;
                        LineABC[1].SanLuongThucTe = 0;
                        LineABC[2].SanLuongTuTao = 0;
                        LineABC[2].SanLuongThucTe = 0;
                        LineABC[3].SanLuongTuTao = 0;
                        LineABC[3].SanLuongThucTe = 0;
                        LineABC[4].SanLuongTuTao = 0;
                        LineABC[4].SanLuongThucTe = 0;
                        LineABC[5].SanLuongThucTe = 0;
                    }
                    if (App.ModelMain.SumTime == 5)
                        LineABC[5].SanLuongChenh = LineABC[5].SanLuongThucTe - LineABC[5].SanLuongTuTao;
                    if ((Step == 0 && (Thistime >= Data[0].From && Thistime < Data[0].To) || (Thistime >= Data[5].From && Thistime < Data[5].To))
                        || ((Step == 0) && (Thistime >= Data[1].From && Thistime < Data[1].To) || (Thistime >= Data[6].From && Thistime < Data[6].To))
                        || ((Step == 0) && (Thistime >= Data[2].From && Thistime < Data[2].To) || (Thistime >= Data[7].From && Thistime < Data[7].To))
                        || (Step == 0) && (Thistime >= Data[3].From && Thistime < Data[3].To) || (Thistime >= Data[8].From && Thistime < Data[8].To)
                        || (Step == 0) && (Thistime >= Data[4].From && Thistime < Data[4].To && App.ModelMain.SumTime == 5) || (Thistime >= Data[9].From && Thistime < Data[9].To && App.ModelMain.SumTime == 5))
                    {
                        Num = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss.ffff"));
                        Step = 1;

                    }
                    if (Step == 1 && ((Thistime - Num).TotalMilliseconds >= AutoTimer))
                    {
                        if ((Thistime >= Data[0].From && Thistime <= Data[0].To) || (Thistime >= Data[5].From && Thistime <= Data[5].To))
                        {
                            LineABC[0].SanLuongTuTao++;
                            LineABC[0].Mausac = "GREEN";
                            LineABC[1].Mausac = "WHITE";
                            LineABC[2].Mausac = "WHITE";
                            LineABC[3].Mausac = "WHITE";
                            if (App.ModelMain.SumTime == 5)
                                LineABC[4].Mausac = "WHITE";
                            Step = 0;
                        }
                        if ((Thistime >= Data[1].From && Thistime < Data[1].To) || (Thistime >= Data[6].From && Thistime < Data[6].To))
                        {
                            LineABC[1].SanLuongTuTao++;
                            LineABC[1].Mausac = "GREEN";
                            LineABC[0].Mausac = "WHITE";
                            LineABC[2].Mausac = "WHITE";
                            LineABC[3].Mausac = "WHITE";
                            if (App.ModelMain.SumTime == 5)
                                LineABC[4].Mausac = "WHITE";
                            Step = 0;
                        }
                        if ((Thistime >= Data[2].From && Thistime < Data[2].To) || (Thistime >= Data[7].From && Thistime < Data[7].To))
                        {
                            LineABC[2].SanLuongTuTao++;
                            LineABC[2].Mausac = "GREEN";
                            LineABC[1].Mausac = "WHITE";
                            LineABC[0].Mausac = "WHITE";
                            LineABC[3].Mausac = "WHITE";
                            if (App.ModelMain.SumTime == 5)
                                LineABC[4].Mausac = "WHITE";
                            Step = 0;
                        }
                        if ((Thistime >= Data[3].From && Thistime < Data[3].To) || (Thistime >= Data[8].From && Thistime < Data[8].To))
                        {
                            LineABC[3].SanLuongTuTao++;
                            LineABC[3].Mausac = "GREEN";
                            LineABC[1].Mausac = "WHITE";
                            LineABC[2].Mausac = "WHITE";
                            LineABC[0].Mausac = "WHITE";
                            if (App.ModelMain.SumTime == 5)
                                LineABC[4].Mausac = "WHITE";
                            Step = 0;
                        }
                        if ((Thistime >= Data[4].From && Thistime < Data[4].To && App.ModelMain.SumTime == 5) || (Thistime >= Data[9].From && Thistime < Data[9].To && App.ModelMain.SumTime == 5))
                        {
                            LineABC[4].SanLuongTuTao++;
                            LineABC[4].Mausac = "GREEN";
                            LineABC[1].Mausac = "WHITE";
                            LineABC[2].Mausac = "WHITE";
                            LineABC[0].Mausac = "WHITE";
                            LineABC[3].Mausac = "WHITE";
                            Step = 0;
                        }
                    }
                    if (App.ModelMain.SumTime == 5)
                        LineABC[5].SanLuongThucTe = LineABC[0].SanLuongThucTe + LineABC[1].SanLuongThucTe + LineABC[2].SanLuongThucTe
                           + LineABC[3].SanLuongThucTe + LineABC[4].SanLuongThucTe;
                    else
                    {
                        LineABC[4].SanLuongThucTe = LineABC[0].SanLuongThucTe + LineABC[1].SanLuongThucTe + LineABC[2].SanLuongThucTe
                       + LineABC[3].SanLuongThucTe;
                    }




                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task MAINLoopTask(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    //Thread.Sleep(5);
                    //token.ThrowIfCancellationRequested();
                    //var NHAN = await App.MAIN.ReadGPIO();
                    //if (NHAN != null)
                    //{
                    //    Start = 1;
                    //    Rise = 0;
                    //}
                    //else if ((NHAN == null && Start == 1) || (NHAN == null && Rise == 0))
                    //{
                    //    Rise = 1;
                    //    Start = 0;
                    //    MessageBox.Show("check power main stm32 f103c8t6", "Thongbao", MessageBoxButton.YesNoCancel);
                    //}

                }
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GridThucTe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Gridclick = sender as Grid;
            var Gridsender = (LineStatus)Gridclick.DataContext;
            SettingSanLuong Sanluong = new SettingSanLuong(Gridsender);
            Sanluong.ShowDialog();
        }

        private void GridTutao_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var Gridclick = sender as Grid;
            var Gridsender = (LineStatus)Gridclick.DataContext;
            SanLuongTutao WindowTutao = new SanLuongTutao(Gridsender);
            WindowTutao.ShowDialog();
        }

        //private async void TbAuto_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    if (TbAuto.Text == App.ModelMain.ModelName)
        //    {
        //        if ((Thistime >= Data[0].From && Thistime <= Data[0].To) || (Thistime >= Data[5].From && Thistime <= Data[5].To))
        //        {
        //            LineABC[0].SanLuongThucTe++;
        //            TbAuto.Clear();
        //        }
        //        if ((Thistime >= Data[1].From && Thistime <= Data[1].To) || (Thistime >= Data[6].From && Thistime <= Data[6].To))
        //        {
        //            LineABC[1].SanLuongThucTe++;
        //            TbAuto.Clear();
        //        }
        //        if ((Thistime >= Data[2].From && Thistime <= Data[2].To) || (Thistime >= Data[7].From && Thistime <= Data[7].To))
        //        {
        //            LineABC[2].SanLuongThucTe++;
        //            TbAuto.Clear();
        //        }
        //        if ((Thistime >= Data[3].From && Thistime <= Data[3].To) || (Thistime >= Data[8].From && Thistime <= Data[8].To))
        //        {
        //            LineABC[3].SanLuongThucTe++;
        //            TbAuto.Clear();
        //        }
        //        if ((Thistime >= Data[4].From && Thistime <= Data[4].To && App.ModelMain.SumTime == 5) || (Thistime >= Data[9].From && Thistime <= Data[9].To && App.ModelMain.SumTime == 5))
        //        {
        //            LineABC[4].SanLuongThucTe++;
        //            TbAuto.Clear();
        //        }
        //    }
        //    else
        //    {
        //        await Task.Delay(200);
        //        TbAuto.Clear();
        //    }

        //}
        public string KeycodeToChar(Key keyCode)
        {
            Key key = (Key)keyCode;

            switch (key)
            {
                case Key.Add:
                    return "+";
                case Key.Decimal:
                    return ".";
                case Key.Divide:
                    return "/";
                case Key.Multiply:
                    return "*";
                case Key.OemBackslash:
                    return "\\";
                case Key.OemCloseBrackets:
                    return "]";
                case Key.OemMinus:
                    return "-";
                case Key.OemOpenBrackets:
                    return "[";
                case Key.OemPeriod:
                    return ".";
                case Key.OemPipe:
                    return "|";
                case Key.OemQuestion:
                    return "/";
                case Key.OemQuotes:
                    return "\"";
                case Key.OemSemicolon:
                    return ";";
                case Key.OemComma:
                    return ",";
                case Key.OemPlus:
                    return "+";
                case Key.OemTilde:
                    return "`";
                case Key.Separator:
                    return "-";
                case Key.Subtract:
                    return "-";
                case Key.D0:
                    return "0";
                case Key.D1:
                    return "1";
                case Key.D2:
                    return "2";
                case Key.D3:
                    return "3";
                case Key.D4:
                    return "4";
                case Key.D5:
                    return "5";
                case Key.D6:
                    return "6";
                case Key.D7:
                    return "7";
                case Key.D8:
                    return "8";
                case Key.D9:
                    return "9";
                case Key.Space:
                    return " ";
                case Key.LeftShift:
                    return "";
                default:
                    return key.ToString();
            }
        }
    }
}

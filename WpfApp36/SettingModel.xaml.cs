using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp36
{
    /// <summary>
    /// Interaction logic for SettingModel.xaml
    /// </summary>
    public partial class SettingModel : Window, INotifyPropertyChanged
    {
        public SettingModel()
        {
            InitializeComponent();
            Loaded += SettingModel_Loaded;
        }
        public static ObservableCollection<KeyValue> KeyABC;
        public static ObservableCollection<MoDel> ModelABC;
        public static ObservableCollection<ModelTimer> ModelTimerABC;
        public static List<KeyValue> KeyData;
        public static List<MoDel> ModelData;
        public static List<ModelTimer> ModelTimerData;
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public string _LineName;
        public string LineName
        {
            get { return _LineName; }
            set
            {
                if (_LineName != value)
                {
                    _LineName = value;
                    NotifyPropertyChanged("LineName");
                }
            }
        }
        public string _Worker;
        public string Worker
        {
            get { return _Worker; }
            set
            {
                if (_Worker != value)
                {
                    _Worker = value;
                    NotifyPropertyChanged("Worker");
                }
            }
        }
        public string _ModelName;
        public string ModelName
        {
            get { return _ModelName; }
            set
            {
                if (_ModelName != value)
                {
                    _ModelName = value;
                    NotifyPropertyChanged("ModelName");
                }
            }
        }
        public int _Target;
        public int Target
        {
            get { return _Target; }
            set
            {
                if (_Target != value)
                {
                    _Target = value;
                    NotifyPropertyChanged("Target");
                }
            }
        }
        public int _NumTime;
        public int NumTime
        {
            get { return _NumTime; }
            set
            {
                if (_NumTime != value)
                {
                    _NumTime = value;
                    NotifyPropertyChanged("NumTime");
                    if(_NumTime==4)
                    {
                        TBLEtime.Text ="";
                        TBFromDayE.Visibility = Visibility.Hidden;
                        TBToDay.Visibility = Visibility.Hidden;
                        TBNightToE.Visibility = Visibility.Hidden;
                        TBNightFromE.Visibility = Visibility.Hidden;
                    }
                    else if(_NumTime==5)
                    {
                        TBLEtime.Text = "E";
                        TBFromDayE.Visibility = Visibility.Visible;
                        TBToDay.Visibility = Visibility.Visible;
                        TBNightToE.Visibility = Visibility.Visible;
                        TBNightFromE.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        public string _ATimeFrom;
        public string ATimeFrom
        {
            get { return _ATimeFrom; }
            set
            {
                if(_ATimeFrom!=value)
                {
                    _ATimeFrom = value;
                    NotifyPropertyChanged("ATimeFrom");
                }
            }
        }
        public string _ATimeTo;
        public string ATimeTo
        {
            get { return _ATimeTo; }
            set
            {
                if (_ATimeTo != value)
                {
                    _ATimeTo = value;
                    NotifyPropertyChanged("ATimeTo");
                }
            }
        }
        public string _BTimeFrom;
        public string BTimeFrom
        {
            get { return _BTimeFrom; }
            set
            {
                if (_BTimeFrom != value)
                {
                    _BTimeFrom = value;
                    NotifyPropertyChanged("BTimeFrom");
                }
            }
        }
        public string _BTimeTo;
        public string BTimeTo
        {
            get { return _BTimeTo; }
            set
            {
                if (_BTimeTo != value)
                {
                    _BTimeTo = value;
                    NotifyPropertyChanged("BTimeTo");
                }
            }
        }
        public string _CTimeFrom;
        public string CTimeFrom
        {
            get { return _CTimeFrom; }
            set
            {
                if (_CTimeFrom != value)
                {
                    _CTimeFrom = value;
                    NotifyPropertyChanged("CTimeFrom");
                }
            }
        }
        public string _CTimeTo;
        public string CTimeTo
        {
            get { return _CTimeTo; }
            set
            {
                if (_CTimeTo != value)
                {
                    _CTimeTo = value;
                    NotifyPropertyChanged("CTimeTo");
                }
            }
        }
        public string _DTimeFrom;
        public string DTimeFrom
        {
            get { return _DTimeFrom; }
            set
            {
                if (_DTimeFrom != value)
                {
                    _DTimeFrom = value;
                    NotifyPropertyChanged("DTimeFrom");
                }
            }
        }
        public string _DTimeTo;
        public string DTimeTo
        {
            get { return _DTimeTo; }
            set
            {
                if (_DTimeTo != value)
                {
                    _DTimeTo = value;
                    NotifyPropertyChanged("DTimeTo");
                }
            }
        }
        public string _ETimeFrom;
        public string ETimeFrom
        {
            get { return _ETimeFrom; }
            set
            {
                if (_ETimeFrom != value)
                {
                    _ETimeFrom = value;
                    NotifyPropertyChanged("ETimeFrom");
                }
            }
        }
        public string _ETimeTo;
        public string ETimeTo
        {
            get { return _ETimeTo; }
            set
            {
                if (_ETimeTo != value)
                {
                    _ETimeTo = value;
                    NotifyPropertyChanged("ETimeTo");
                }
            }
        }
        public string _ATimeFromNight;
        public string ATimeFromNight
        {
            get { return _ATimeFromNight; }
            set
            {
                if (_ATimeFromNight != value)
                {
                    _ATimeFromNight = value;
                    NotifyPropertyChanged("ATimeFromNight");
                }
            }
        }
        public string _ATimeToNight;
        public string ATimeToNight
        {
            get { return _ATimeToNight; }
            set
            {
                if (_ATimeToNight != value)
                {
                    _ATimeToNight = value;
                    NotifyPropertyChanged("ATimeToNight");
                }
            }
        }
        public string _BTimeFromNight;
        public string BTimeFromNight
        {
            get { return _BTimeFromNight; }
            set
            {
                if (_BTimeFromNight != value)
                {
                    _BTimeFromNight = value;
                    NotifyPropertyChanged("BTimeFromNight");
                }
            }
        }
        public string _BTimeToNight;
        public string BTimeToNight
        {
            get { return _BTimeToNight; }
            set
            {
                if (_BTimeToNight != value)
                {
                    _BTimeToNight = value;
                    NotifyPropertyChanged("BTimeToNight");
                }
            }
        }
        public string _CTimeFromNight;
        public string CTimeFromNight
        {
            get { return _CTimeFromNight; }
            set
            {
                if (_CTimeFromNight != value)
                {
                    _CTimeFromNight = value;
                    NotifyPropertyChanged("CTimeFromNight");
                }
            }
        }
        public string _CTimeToNight;
        public string CTimeToNight
        {
            get { return _CTimeToNight; }
            set
            {
                if (_CTimeToNight != value)
                {
                    _CTimeToNight = value;
                    NotifyPropertyChanged("CTimeToNight");
                }
            }
        }
        public string _DTimeFromNight;
        public string DTimeFromNight
        {
            get { return _DTimeFromNight; }
            set
            {
                if (_DTimeFromNight != value)
                {
                    _DTimeFromNight = value;
                    NotifyPropertyChanged("DTimeFromNight");
                }
            }
        }
        public string _DTimeToNight;
        public string DTimeToNight
        {
            get { return _DTimeToNight; }
            set
            {
                if (_DTimeToNight != value)
                {
                    _DTimeToNight = value;
                    NotifyPropertyChanged("DTimeToNight");
                }
            }
        }
        public string _ETimeFromNight;
        public string ETimeFromNight
        {
            get { return _ETimeFromNight; }
            set
            {
                if (_ETimeFromNight != value)
                {
                    _ETimeFromNight = value;
                    NotifyPropertyChanged("ETimeFromNight");
                }
            }
        }
        public string _ETimeToNight;
        public string ETimeToNight
        {
            get { return _ETimeToNight; }
            set
            {
                if (_ETimeToNight != value)
                {
                    _ETimeToNight = value;
                    NotifyPropertyChanged("ETimeToNight");
                }
            }
        }
        private void Init()
        {
            KeyABC = new ObservableCollection<KeyValue>();
            ModelABC = new ObservableCollection<MoDel>();
            ModelTimerABC = new ObservableCollection<ModelTimer>();
            var _Key1 = KeyData.Where(x => x.Key == "LINE 1").FirstOrDefault();
            if (_Key1 != null)
            {
                KeyABC.Add(_Key1);
            }
            var _Key2 = KeyData.Where(x => x.Key == "LINE 2").FirstOrDefault();
            if (_Key2 != null)
            {
                KeyABC.Add(_Key2);
            }
            var _Key3 = KeyData.Where(x => x.Key == "LINE 3").FirstOrDefault();
            if (_Key3 != null)
            {
                KeyABC.Add(_Key3);
            }
            var _Key4 = KeyData.Where(x => x.Key == "LINE 4").FirstOrDefault();
            if (_Key4 != null)
            {
                KeyABC.Add(_Key4);
            }
            var _Key5 = KeyData.Where(x => x.Key == "LINE 5").FirstOrDefault();
            if (_Key5 != null)
            {
                KeyABC.Add(_Key5);
            }
            var _Key6 = KeyData.Where(x => x.Key == "LINE 6").FirstOrDefault();
            if (_Key6 != null)
            {
                KeyABC.Add(_Key6);
            }
            var _Key7 = KeyData.Where(x => x.Key == "LINE 7").FirstOrDefault();
            if (_Key7 != null)
            {
                KeyABC.Add(_Key7);
            }
            var _Key8 = KeyData.Where(x => x.Key == "LINE 8").FirstOrDefault();
            if (_Key8 != null)
            {
                KeyABC.Add(_Key8);
            }
            var _Key9 = KeyData.Where(x => x.Key == "LINE 9").FirstOrDefault();
            if (_Key9 != null)
            {
                KeyABC.Add(_Key9);

            }
            var _Key10 = KeyData.Where(x => x.Key == "LINE 10").FirstOrDefault();
            if (_Key10 != null)
            {
                KeyABC.Add(_Key10);
            }
            var _Key11 = KeyData.Where(x => x.Key == "LINE 11").FirstOrDefault();
            if (_Key11 != null)
            {
                KeyABC.Add(_Key11);
            }
            var _Key12 = KeyData.Where(x => x.Key == "LINE 12").FirstOrDefault();
            if (_Key12 != null)
            {
                KeyABC.Add(_Key12);
            }
            var _Key13 = KeyData.Where(x => x.Key == "LINE 13").FirstOrDefault();
            if (_Key13 != null)
            {
                KeyABC.Add(_Key13);
            }
            var _Key14 = KeyData.Where(x => x.Key == "LINE 14").FirstOrDefault();
            if (_Key14 != null)
            {
                KeyABC.Add(_Key14);
            }
            var _Key15 = KeyData.Where(x => x.Key == "LINE 15").FirstOrDefault();
            if (_Key15 != null)
            {
                KeyABC.Add(_Key15);
            }
            var _Model1 = ModelData.Where(x => x.ModelLabel == "MODEL 1").FirstOrDefault();
            if (_Model1 != null)
            {
                ModelABC.Add(_Model1);
            }
            var _Model2 = ModelData.Where(x => x.ModelLabel == "MODEL 2").FirstOrDefault();
            if (_Model2 != null)
            {
                ModelABC.Add(_Model2);
            }
            var _Model3 = ModelData.Where(x => x.ModelLabel == "MODEL 3").FirstOrDefault();
            if (_Model3 != null)
            {
                ModelABC.Add(_Model3);
            }
            var _Model4 = ModelData.Where(x => x.ModelLabel == "MODEL 4").FirstOrDefault();
            if (_Model4 != null)
            {
                ModelABC.Add(_Model4);
            }
            var _Model5 = ModelData.Where(x => x.ModelLabel == "MODEL 5").FirstOrDefault();
            if (_Model5 != null)
            {
                ModelABC.Add(_Model5);
            }
            var _Model6 = ModelData.Where(x => x.ModelLabel == "MODEL 6").FirstOrDefault();
            if (_Model6 != null)
            {
                ModelABC.Add(_Model6);
            }
            var _Model7 = ModelData.Where(x => x.ModelLabel == "MODEL 7").FirstOrDefault();
            if (_Model7 != null)
            {
                ModelABC.Add(_Model7);
            }
            var _Model8 = ModelData.Where(x => x.ModelLabel == "MODEL 8").FirstOrDefault();
            if (_Model8 != null)
            {
                ModelABC.Add(_Model8);
            }
            var _Model9 = ModelData.Where(x => x.ModelLabel == "MODEL 9").FirstOrDefault();
            if (_Model9 != null)
            {
                ModelABC.Add(_Model9);
            }
            var _Model10 = ModelData.Where(x => x.ModelLabel == "MODEL 10").FirstOrDefault();
            if (_Model10 != null)
            {
                ModelABC.Add(_Model10);
            }
            var _Model11 = ModelData.Where(x => x.ModelLabel == "MODEL 11").FirstOrDefault();
            if (_Model11 != null)
            {
                ModelABC.Add(_Model11);
            }
            var _Model12 = ModelData.Where(x => x.ModelLabel == "MODEL 12").FirstOrDefault();
            if (_Model12 != null)
            {
                ModelABC.Add(_Model12);
            }
            var _Model13 = ModelData.Where(x => x.ModelLabel == "MODEL 13").FirstOrDefault();
            if (_Model13 != null)
            {
                ModelABC.Add(_Model13);
            }
            var _Time1 = ModelTimerData.Where(x => x.ModelTimerName == "MAIN 1").FirstOrDefault();
            if(_Time1!=null)
            {
                ModelTimerABC.Add(_Time1);
            }
            var _Time2 = ModelTimerData.Where(x => x.ModelTimerName == "MAIN 2").FirstOrDefault();
            if (_Time2 != null)
            {
                ModelTimerABC.Add(_Time2);
            }
            var _Time3 = ModelTimerData.Where(x => x.ModelTimerName == "MAIN 3").FirstOrDefault();
            if (_Time3 != null)
            {
                ModelTimerABC.Add(_Time3);
            }
            var _Time4 = ModelTimerData.Where(x => x.ModelTimerName == "MAIN 4").FirstOrDefault();
            if (_Time4 != null)
            {
                ModelTimerABC.Add(_Time4);
            }
            var _Time5 = ModelTimerData.Where(x => x.ModelTimerName == "MAIN 5").FirstOrDefault();
            if (_Time5 != null)
            {
                ModelTimerABC.Add(_Time5);
            }
            CbLine.ItemsSource = KeyABC;
            CbLine.DisplayMemberPath = "Key";
            CbLine.SelectionChanged += CbLine_SelectionChanged;
            CbModel.ItemsSource = ModelABC;
            CbModel.DisplayMemberPath = "ModelLabel";
            CbModel.SelectionChanged += CbModel_SelectionChanged;
            CbModelTime.ItemsSource = ModelTimerABC;
            CbModelTime.DisplayMemberPath = "ModelTimerName";
            CbModelTime.SelectionChanged += CbModelTime_SelectionChanged;
            DataContext = this;
        }

        private void CbModelTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                ModelTimer food = cb.SelectedItem as ModelTimer;
                ATimeFrom = food.TimeAFrom;
                ATimeTo = food.TimeATo;
                BTimeFrom = food.TimeBFrom;
                BTimeTo = food.TimeBTo;
                CTimeFrom = food.TimeCFrom;
                CTimeTo = food.TimeCTo;
                DTimeFrom = food.TimeDFrom;
                DTimeTo = food.TimeDTo;
                ETimeFrom = food.TimeEFrom;
                ETimeTo = food.TimeETo;
                ATimeFromNight = food.TimeAFromNight;
                ATimeToNight = food.TimeAToNight;
                BTimeFromNight = food.TimeBFromNight;
                BTimeToNight = food.TimeBToNight;
                CTimeFromNight = food.TimeCFromNight;
                CTimeToNight = food.TimeCToNight;
                DTimeFromNight = food.TimeDFromNight;
                DTimeToNight = food.TimeDToNight;
                ETimeFromNight = food.TimeEFromNight;
                ETimeToNight = food.TimeEToNight;
            }
        }

        private void CbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                MoDel food = cb.SelectedItem as MoDel;
                ModelName = food.ModelName;
                Target = food.Production;
                NumTime = food.SumTime;

            }
        }

        private void CbLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                KeyValue food = cb.SelectedItem as KeyValue;
                LineName = food.NameLeaDer;
                Worker = food.NhanLuc;

            }
        }

        private void SettingModel_Loaded(object sender, RoutedEventArgs e)
        {
            using (var Db = new SettingContect())
            {
                KeyData = Db.KeyValues.ToList();
                ModelData = Db.MoDels.ToList();
                ModelTimerData = Db.ModelTimers.ToList();
            }
            Init();
        }

        private void SaveLine_Click(object sender, RoutedEventArgs e)
        {
            if(CbLine.SelectedItem!=null)
            {
                using (var Db = new SettingContect())
                {
                    var LineSave = Db.KeyValues.Where(x => x.Key == CbLine.Text).FirstOrDefault();
                    if (LineSave != null)
                    {
                        LineSave.NameLeaDer = LineName;
                        LineSave.NhanLuc = Worker;
                        Db.SaveChanges();
                    }

                }
            }
            else
            {
                MessageBox.Show("Data Input Line error?");
            }
        }

        private void SaveModel_Click(object sender, RoutedEventArgs e)
        {
            if (CbModel.SelectedItem != null)
            {
                using (var Db = new SettingContect())
                {
                    var ModelSave = Db.MoDels.Where(x => x.ModelLabel == CbModel.Text).FirstOrDefault();
                    if (ModelSave != null)
                    {
                        ModelSave.ModelName = ModelName;
                        ModelSave.Production = Target;
                        ModelSave.SumTime = NumTime;
                        Db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data Input Model  error?");
            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CbLine.SelectedItem != null && CbModel.SelectedItem != null&&CbModelTime.SelectedItem!=null)
                {
                    App.KeyValueMain.NameLeaDer = LineName;
                    App.KeyValueMain.Key = CbLine.Text;
                    App.KeyValueMain.NhanLuc = Worker;
                    App.ModelMain.ModelName = ModelName;
                    App.ModelMain.Production = Target;
                    App.ModelMain.SumTime = NumTime;
                    App.ModelTimerMain.TimeAFrom = ATimeFrom;
                    App.ModelTimerMain.TimeATo = ATimeTo;
                    App.ModelTimerMain.TimeBFrom = BTimeFrom;
                    App.ModelTimerMain.TimeBTo = BTimeTo;
                    App.ModelTimerMain.TimeCFrom = CTimeFrom;
                    App.ModelTimerMain.TimeCTo = CTimeTo;
                    App.ModelTimerMain.TimeDFrom = DTimeFrom;
                    App.ModelTimerMain.TimeDTo = DTimeTo;
                    App.ModelTimerMain.TimeEFrom = ETimeFrom;
                    App.ModelTimerMain.TimeETo = ETimeTo;
                    App.ModelTimerMain.TimeAFromNight = ATimeFromNight;
                    App.ModelTimerMain.TimeAToNight = ATimeToNight;
                    App.ModelTimerMain.TimeBFromNight = BTimeFromNight;
                    App.ModelTimerMain.TimeBToNight = BTimeToNight;
                    App.ModelTimerMain.TimeCFromNight = CTimeFromNight;
                    App.ModelTimerMain.TimeCToNight = CTimeToNight;
                    App.ModelTimerMain.TimeDFromNight = DTimeFromNight;
                    App.ModelTimerMain.TimeDToNight = DTimeToNight;
                    App.ModelTimerMain.TimeEFromNight = ETimeFromNight;
                    App.ModelTimerMain.TimeEToNight = ETimeToNight;
                    AutoPage autoPage = new AutoPage();
                    MainWindow.AutoFram.Navigate(autoPage);
                    Close();
                }
                else
                {
                    MessageBox.Show("Input Model Line or ModelTimer error?");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Data Input Model Line ModelTimer error?");
            }

        }

        private void SaveModelTimer_Click(object sender, RoutedEventArgs e)
        {
            if(CbModelTime!=null)
            {
                using (var Db = new SettingContect())
                {
                    var ModelTimerSave = Db.ModelTimers.Where(x => x.ModelTimerName == CbModelTime.Text).FirstOrDefault();
                    if (ModelTimerSave != null)
                    {
                        ModelTimerSave.TimeAFrom = ATimeFrom;
                        ModelTimerSave.TimeATo = ATimeTo;
                        ModelTimerSave.TimeBFrom = BTimeFrom;
                        ModelTimerSave.TimeBTo = BTimeTo;
                        ModelTimerSave.TimeCFrom = CTimeFrom;
                        ModelTimerSave.TimeCTo = CTimeTo;
                        ModelTimerSave.TimeDFrom = DTimeFrom;
                        ModelTimerSave.TimeDTo = DTimeTo;
                        ModelTimerSave.TimeEFrom = ETimeFrom;
                        ModelTimerSave.TimeETo = ETimeTo;
                        ModelTimerSave.TimeAFromNight = ATimeFromNight;
                        ModelTimerSave.TimeAToNight = ATimeToNight;
                        ModelTimerSave.TimeBFromNight = BTimeFromNight;
                        ModelTimerSave.TimeBToNight = BTimeToNight;
                        ModelTimerSave.TimeCFromNight = CTimeFromNight;
                        ModelTimerSave.TimeCToNight = CTimeToNight;
                        ModelTimerSave.TimeDFromNight = DTimeFromNight;
                        ModelTimerSave.TimeDToNight = DTimeToNight;
                        ModelTimerSave.TimeEFromNight = ETimeFromNight;
                        ModelTimerSave.TimeEToNight = ETimeToNight;
                        Db.SaveChanges();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data Input ModelTimer error?");
            }
        }
    }
}

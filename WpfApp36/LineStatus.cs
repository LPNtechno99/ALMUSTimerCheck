using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp36
{
    public class LineStatus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [Key]
        public int LineId { get; set; }
        public string LineName { get; set; }
        
        public int _SanLuongThucTe;
        public int SanLuongThucTe
        {
            get { return _SanLuongThucTe; }
            set
            {
                if (_SanLuongThucTe != value)
                {
                    _SanLuongThucTe = value;
                    NotifyPropertyChanged("SanLuongThucTe");
                }
            }
        }
        public int _SanLuongChenh;
        public int SanLuongChenh
        {
            get { return _SanLuongChenh; }
            set
            {
                if (_SanLuongChenh != value)
                {
                    _SanLuongChenh = value;
                    NotifyPropertyChanged("SanLuongChenh");
                }
            }
        }
        public int _SanLuongTuTao;
        public int SanLuongTuTao
        {
            get { return _SanLuongTuTao; }
            set
            {
                if(_SanLuongTuTao!=value)
                {
                    _SanLuongTuTao = value;
                    NotifyPropertyChanged("SanLuongTuTao");
                }
            }
        }
        public string _Mausac;
        public string Mausac
        {
            get { return _Mausac; }
            set
            {
                if(_Mausac!=value)
                {
                    _Mausac = value;
                    NotifyPropertyChanged("Mausac");
                }
            }
        }
        
    }
    public class KeyValue: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [Key]
        public int KeyValueID { get; set; }
        public string Key { get; set; }
        public string NhanLuc { get; set; }
        public string _NameLeaDer;
        public string NameLeaDer
        {
            get { return _NameLeaDer; }
            set
            {
                if(_NameLeaDer != value)
                {
                    _NameLeaDer = value;
                    NotifyPropertyChanged("NameLeaDer");
                }
            }
        }

    }
    public class MoDel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [Key]
        public int ModelID { get; set; }
        public string ModelLabel { get; set; }
        public string ModelName { get; set; }
        public int _SumTime;
        public int SumTime
        {
            get { return _SumTime; }
            set
            {
                if(_SumTime!=value)
                {
                    _SumTime = value;
                    NotifyPropertyChanged("SumTime");
                }
            }
        }
        public int _Production;
        public int Production
        {
            get { return _Production; }
            set
            {
                if (_Production != value)
                {
                    _Production = value;
                    NotifyPropertyChanged("Value");
                }
            }
        }

    }
    public class ModelTimer : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [Key]
        public int ModelTimerId { get; set; }
        public string ModelTimerName { get; set; }
        public string _TimeAFrom;
        public string TimeAFrom
        {
            get { return _TimeAFrom; }
            set
            {
                if(_TimeAFrom!=value)
                {
                    _TimeAFrom = value;
                    NotifyPropertyChanged("TimeAFrom");
                }
            }
        }
        public string _TimeATo;
        public string TimeATo
        {
            get { return _TimeATo; }
            set
            {
                if (_TimeATo != value)
                {
                    _TimeATo = value;
                    NotifyPropertyChanged("TimeATo");
                }
            }
        }
        public string _TimeBFrom;
        public string TimeBFrom
        {
            get { return _TimeBFrom; }
            set
            {
                if (_TimeBFrom != value)
                {
                    _TimeBFrom = value;
                    NotifyPropertyChanged("TimeBFrom");
                }
            }
        }
        public string _TimeBTo;
        public string TimeBTo
        {
            get { return _TimeBTo; }
            set
            {
                if (_TimeBTo != value)
                {
                    _TimeBTo = value;
                    NotifyPropertyChanged("TimeBTo");
                }
            }
        }
        public string _TimeCFrom;
        public string TimeCFrom
        {
            get { return _TimeCFrom; }
            set
            {
                if (_TimeCFrom != value)
                {
                    _TimeCFrom = value;
                    NotifyPropertyChanged("TimeCFrom");
                }
            }
        }
        public string _TimeCTo;
        public string TimeCTo
        {
            get { return _TimeCTo; }
            set
            {
                if (_TimeCTo != value)
                {
                    _TimeCTo = value;
                    NotifyPropertyChanged("TimeCTo");
                }
            }
        }
        public string _TimeDFrom;
        public string TimeDFrom
        {
            get { return _TimeDFrom; }
            set
            {
                if (_TimeDFrom != value)
                {
                    _TimeDFrom = value;
                    NotifyPropertyChanged("TimeDFrom");
                }
            }
        }
        public string _TimeDTo;
        public string TimeDTo
        {
            get { return _TimeDTo; }
            set
            {
                if (_TimeDTo != value)
                {
                    _TimeDTo = value;
                    NotifyPropertyChanged("TimeDTo");
                }
            }
        }
        public string _TimeEFrom;
        public string TimeEFrom
        {
            get { return _TimeEFrom; }
            set
            {
                if (_TimeEFrom != value)
                {
                    _TimeEFrom = value;
                    NotifyPropertyChanged("TimeEFrom");
                }
            }
        }
        public string _TimeETo;
        public string TimeETo
        {
            get { return _TimeETo; }
            set
            {
                if (_TimeETo != value)
                {
                    _TimeETo = value;
                    NotifyPropertyChanged("TimeETo");
                }
            }
        }
        public string _TimeAFromNight;
        public string TimeAFromNight
        {
            get { return _TimeAFromNight; }
            set
            {
                if (_TimeAFromNight != value)
                {
                    _TimeAFromNight = value;
                    NotifyPropertyChanged("TimeAFromNight");
                }
            }
        }
        public string _TimeAToNight;
        public string TimeAToNight
        {
            get { return _TimeAToNight; }
            set
            {
                if (_TimeAToNight != value)
                {
                    _TimeAToNight = value;
                    NotifyPropertyChanged("TimeAToNight");
                }
            }
        }
        public string _TimeBFromNight;
        public string TimeBFromNight
        {
            get { return _TimeBFromNight; }
            set
            {
                if (_TimeBFromNight != value)
                {
                    _TimeBFromNight = value;
                    NotifyPropertyChanged("TimeBFromNight");
                }
            }
        }
        public string _TimeBToNight;
        public string TimeBToNight
        {
            get { return _TimeBToNight; }
            set
            {
                if (_TimeBToNight != value)
                {
                    _TimeBToNight = value;
                    NotifyPropertyChanged("TimeBToNight");
                }
            }
        }
        public string _TimeCFromNight;
        public string TimeCFromNight
        {
            get { return _TimeCFromNight; }
            set
            {
                if (_TimeCFromNight != value)
                {
                    _TimeCFromNight = value;
                    NotifyPropertyChanged("TimeCFromNight");
                }
            }
        }
        public string _TimeCToNight;
        public string TimeCToNight
        {
            get { return _TimeCToNight; }
            set
            {
                if (_TimeCToNight != value)
                {
                    _TimeCToNight = value;
                    NotifyPropertyChanged("TimeCToNight");
                }
            }
        }
        public string _TimeDFromNight;
        public string TimeDFromNight
        {
            get { return _TimeDFromNight; }
            set
            {
                if (_TimeDFromNight != value)
                {
                    _TimeDFromNight = value;
                    NotifyPropertyChanged("TimeDFromNight");
                }
            }
        }
        public string _TimeDToNight;
        public string TimeDToNight
        {
            get { return _TimeDToNight; }
            set
            {
                if (_TimeDToNight != value)
                {
                    _TimeDToNight = value;
                    NotifyPropertyChanged("TimeDToNight");
                }
            }
        }
        public string _TimeEFromNight;
        public string TimeEFromNight
        {
            get { return _TimeEFromNight; }
            set
            {
                if (_TimeEFromNight != value)
                {
                    _TimeEFromNight = value;
                    NotifyPropertyChanged("TimeEFromNight");
                }
            }
        }
        public string _TimeEToNight;
        public string TimeEToNight
        {
            get { return _TimeEToNight; }
            set
            {
                if (_TimeEToNight != value)
                {
                    _TimeEToNight = value;
                    NotifyPropertyChanged("TimeEToNight");
                }
            }
        }


    }
    public class DataInit
    {
        public static void DataSeing()
        {
            using (SettingContect Db = new SettingContect())
            {
                if(!Db.LineStatuses.Any())
                {
                    var Seing = new List<LineStatus>()
                    {
                        
                        new LineStatus(){LineName="A-Time"},
                        new LineStatus(){LineName="B-Time"},
                        new LineStatus(){LineName="C-Time"},
                        new LineStatus(){LineName="D-Time"},
                        new LineStatus(){LineName="E-Time"},
                        new LineStatus(){LineName="AcTual"},

                    };
                    Db.AddRange(Seing);
                    Db.SaveChanges();
                }
                if (!Db.KeyValues.Any())
                {
                    var SeedData = new List<KeyValue>()
                    {
                         new KeyValue(){Key="LINE 1"},
                         new KeyValue(){Key="LINE 2"},
                         new KeyValue(){Key="LINE 3"},
                         new KeyValue(){Key="LINE 4"},
                         new KeyValue(){Key="LINE 5"},
                         new KeyValue(){Key="LINE 6"},
                         new KeyValue(){Key="LINE 7"},
                         new KeyValue(){Key="LINE 8"},
                         new KeyValue(){Key="LINE 9"},
                         new KeyValue(){Key="LINE 10"},
                         new KeyValue(){Key="LINE 11"},
                         new KeyValue(){Key="LINE 12"},
                         new KeyValue(){Key="LINE 13"},
                         new KeyValue(){Key="LINE 14"},
                         new KeyValue(){Key="LINE 15"},
                       
                    };
                    Db.AddRange(SeedData);
                    Db.SaveChanges();
                }
                if(!Db.MoDels.Any())
                {
                    var Seding = new List<MoDel>()
                    {
                        new MoDel(){ModelLabel="MODEL 1"},
                        new MoDel(){ModelLabel="MODEL 2"},
                        new MoDel(){ModelLabel="MODEL 3"},
                        new MoDel(){ModelLabel="MODEL 4"},
                        new MoDel(){ModelLabel="MODEL 5"},
                        new MoDel(){ModelLabel="MODEL 6"},
                        new MoDel(){ModelLabel="MODEL 7"},
                        new MoDel(){ModelLabel="MODEL 8"},
                        new MoDel(){ModelLabel="MODEL 9"},
                        new MoDel(){ModelLabel="MODEL 10"},
                        new MoDel(){ModelLabel="MODEL 11"},
                        new MoDel(){ModelLabel="MODEL 12"},
                        new MoDel(){ModelLabel="MODEL 13"},
                    };
                    Db.AddRange(Seding);
                    Db.SaveChanges();
                }
                if(!Db.ModelTimers.Any())
                {
                    var Setting = new List<ModelTimer>()
                    {
                        new ModelTimer(){ModelTimerName="MAIN 1"},
                        new ModelTimer(){ModelTimerName="MAIN 2"},
                        new ModelTimer(){ModelTimerName="MAIN 3"},
                        new ModelTimer(){ModelTimerName="MAIN 4"},
                        new ModelTimer(){ModelTimerName="MAIN 5"}

                    };
                    Db.AddRange(Setting);
                    Db.SaveChanges();
                }

            }
        }
    }
}


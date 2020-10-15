using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp36
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // public static SerialHelper Serial = new SerialHelper("COM12", 57600, 30, "PLC");
        public static SerialHelper MAIN = new SerialHelper("COM10", 115200, 30, "MAIN");
        public static MoDel ModelMain = new MoDel();
        public static ModelTimer ModelTimerMain = new ModelTimer();
        public static KeyValue KeyValueMain = new KeyValue();
        public App()
        {
            using (var db = new SettingContect())
            {
                db.Database.Migrate();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static WpfApp36.PLCResister;

namespace WpfApp36
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }
        public static Frame AutoFram;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AutoFram = MainFram;
            DataInit.DataSeing();
            SettingModel settingModel = new SettingModel();
            settingModel.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(AutoPage._listener!=null)
            AutoPage._listener.UnHookKeyboard();
        }
    }
}

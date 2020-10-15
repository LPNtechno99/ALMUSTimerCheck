using System;
using System.Collections.Generic;
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
    /// Interaction logic for SettingSanLuong.xaml
    /// </summary>
    public partial class SettingSanLuong : Window
    {
        public LineStatus JigPos { get; set; }
        public SettingSanLuong(LineStatus JigPos)
        {
            InitializeComponent();
            this.JigPos = JigPos;
            DataContext = this;

        }

        private void set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult RT = MessageBox.Show("Do you Want chager Result?", "ThongBao", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (RT == MessageBoxResult.Yes)
                {
                    JigPos.SanLuongThucTe = int.Parse(TbMain.Text);
                    AutoPage.AutoButton.Clear();
                }
                    
            }
            catch (Exception)
            {
                AutoPage.AutoButton.Clear();
                MessageBox.Show("Data intput Result Error?");
            }
            
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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

namespace 第二组综合设计地铁购票系统
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }


        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {

            }
        }

        private void win_min_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void win_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void win_min_MouseEnter(object sender, MouseEventArgs e)
        {
            Border bd = sender as Border;
            SolidColorBrush brush = new SolidColorBrush();

            brush.Color = Color.FromArgb(0xFF, 0x19, 0x88, 0x7e);
            bd.Background = brush;
        }

        private void win_min_MouseLeave(object sender, MouseEventArgs e)
        {
            Border bd = sender as Border;
            bd.Background = null;
        }

        private void 售票系统_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new UserLogin().Show();
            this.WindowState = WindowState.Minimized;
        }

        private void 管理系统_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new AdminW().Show();
            this.WindowState = WindowState.Minimized;          
        }
    }
}

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
    /// AdminW.xaml 的交互逻辑
    /// </summary>
    public partial class AdminW : Window
    {
        DateTime dt;
        System.Windows.Threading.DispatcherTimer timer_time;
        public static Window AdminWinstance;
        public  Frame adminf;
        public AdminW()
        {
            AdminWinstance = this;
            adminf = this.adminPage as Frame;
            InitializeComponent();
            adminPage.Content = new Adminpage.openAcount(adminPage);
            timer_time = new System.Windows.Threading.DispatcherTimer();
            timer_time.Interval = TimeSpan.FromSeconds(1);
            timer_time.Tick += Timer_time_Tick;
            timer_time.Start();
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            time.Text = "Server Time: " + s + " CST";
        }
        private void Timer_time_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            time.Text = "Server Time: " + s + " CST";
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
            this.Close();
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            switch(border.Name)
            {
                case "openAccount":
                    adminPage.Content = new Adminpage.openAcount(adminPage);
                    break;
                case "backMima":
                    adminPage.Content = new Adminpage.backmima(adminPage);
                    break;
                case "query":
                    adminPage.Content = new Adminpage.query();
                    break;
                case "chongzhi":
                    adminPage.Content = new Adminpage.充值(adminPage);
                    break;
                case "XXXHHH":
                    adminPage.Content = new Adminpage.Del(adminPage);
                    break;
                default: return;
                    break;

            }
        }
    }
}

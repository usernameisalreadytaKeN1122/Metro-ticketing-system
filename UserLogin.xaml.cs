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
    /// UserLogin.xaml 的交互逻辑
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
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
            Close();
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
        //用户名密码检验
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string username = user.Text.ToString();
                string pass = pas.Password.ToString();
                using(var v =new db.MyDb1())
                {
                    var q = from t in v.User
                            where t.Username.ToString().Equals(username) &&
                              t.password.ToString().Equals(pass)
                            select t;
                    if (q.Count() == 0)
                    {
                        MessageBox.Show("账号密码错误！");
                        return;
                    }
                    else if (q.Count() == 1)
                    {
                        this.Close();
                        new MainWindow().Show();
                        MainWindow.username = username;
                      
                    }
                       
                }
            }
            catch
            {
                MessageBox.Show("登陆失败");
            }
            
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 第二组综合设计地铁购票系统.Adminpage
{
    /// <summary>
    /// backmima.xaml 的交互逻辑
    /// </summary>
    public partial class backmima : Page
    {
        Frame f;
        public backmima(Frame  ff)
            
        {
            f = ff;
            InitializeComponent();
            init();
        }
        public backmima()

        {
            
            InitializeComponent();
            init();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foucss.Focus();
            string us = username.Text.ToString();
            string rena = real_name.Text.ToString();
            string id = shenfenzheng.Text.ToString();
            string ip = phnum.Text.ToString();
            string p = newpass.Password.ToString();
            if (us.Equals("") || rena.Equals("") || id.Equals("")
                || ip.Equals("") || p.Equals(""))
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            using (var v = new db.MyDb1())
            {
                var q = from t in v.User
                        where t.Username.ToString().Equals(username.Text.ToString()) == true
                        select t;
                if (q.Count() == 0)
                {

                    MessageBox.Show("用户名不存在!");
                    return;
                }
                var qq = from t in v.User
                         where t.Username.ToString().Equals(us) &&
                         t.name.ToString().Equals(rena)&&
                         t.IDCard.ToString().Equals(id)&&
                         t.Phonenum.ToString().Equals(ip)
                         select t;
                if (qq.Count() == 0)
                {
                    MessageBox.Show("用户信息错误");
                    return;
                }
               
                if (qq.Count() == 1&&flag==1)
                {
                    foreach(var w in qq)
                    {
                        w.password = newpass.Password.ToString();
                    }
                    v.SaveChanges();
                    //MessageBox.Show("找回成功!");
                    f.Content = new Sucess(this,f);
                    init();
                }
            }
        }
        private void init()
        {
            username.Text = "";
            real_name.Text = "";
            shenfenzheng.Text = "";
            phnum.Text = "";
            newpass.Password = "";
        }
        int flag = 0;
        private void new_pa_LostFocus(object sender, RoutedEventArgs e)
        {
            string pas = newpass.Password.ToString();
            if (pas.Length < 8 || pas.Length > 15)
            {
                new_pa.Text = "*密码长度不正确";
                new_pa.Foreground = Brushes.Red;
                flag = 0;
            }else
            {
                new_pa.Text = "";
                new_pa.Foreground = Brushes.White;
                flag = 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
namespace 第二组综合设计地铁购票系统.Adminpage
{
    /// <summary>
    /// openAcount.xaml 的交互逻辑
    /// </summary>
    public partial class openAcount : Page
    {
        Frame pp;
        public openAcount(Frame p)
        {
            pp = p;
            InitializeComponent();
            setInit();
           
        }



        //用户名框失去焦点检测
        bool f1=false, f2 = false, f3 = false, f4 = false, f5 = false, f6 = false;
        
        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            string nameuse = username.Text.ToString();

            if (!Regex.IsMatch(nameuse, @"^[A-Za-z]{1}[A-Za-z0-9]+$"))
            {
                username1.Text = "*用户名必须以字母开头";
                username1.Foreground = Brushes.Red;
                f1 = false;
              
            }
            else if (nameuse.Length > 9 || nameuse.Length < 6)
            {
                username1.Text = "*用户名长度不符合要求";
                username1.Foreground = Brushes.Red;
                f1 = false;

            }
           else if (db.CheckInfo.checkUsername(nameuse))
            {
                username1.Text = "*用户名重复";
                username1.Foreground = Brushes.Red;
                f1 = false;
            }
            else
            {
                username1.Text = "";
                username1.Foreground = Brushes.White;
                f1 = true;
            }
           
        }
        //密码检测
        private void pas_LostFocus(object sender, RoutedEventArgs e)
        {
            string ps = pas.Password.ToString();
            if (ps.Length < 8||ps.Length>15)
            {
                pas1.Text = "*密码长度不正确";
                pas1.Foreground = Brushes.Red;
                f2 = false;
            }
            else
            {
                pas1.Text = "";
                pas1.Foreground = Brushes.White;
                f2 = true;
            }
        }
        //重复密码检测
        private void rep_pas_LostFocus(object sender, RoutedEventArgs e)
        {
            string ps = pas.Password.ToString();
            string repps = rep_pas.Password.ToString();
            if (ps.Equals(repps))
            {
                rep_pas1.Text = "";
                f3 = true
                    ;
                rep_pas1.Foreground = Brushes.White;
            }
            else
            {
                rep_pas1.Text = "*两次输入密码不一致";
                rep_pas1.Foreground = Brushes.Red;
                f3 = false;
            }
        }
        //名字检测
        private void nam_LostFocus(object sender, RoutedEventArgs e)
        {
            string name_real = nam.Text.ToString();
            if (name_real.Equals(""))
            {
                real_name.Text = "*名字不能为空";
                real_name.Foreground = Brushes.Red;
                f4 = false;
            }
            else
            {
                f4 = true;
                real_name.Text = "";
                real_name.Foreground = Brushes.White;
            }
        }
        //身份证号检测
        private void shenfenzheng_LostFocus(object sender, RoutedEventArgs e)
        {
            string idcard = shenfenzheng.Text.ToString();
            if (idcard.Length != 18||
                !Regex.IsMatch(idcard, "^[1-9]\\d{5}[1-9]\\d{3}((0[1-9])||(1[0-2]))((0[1-9])||(1\\d)||(2\\d)||(3[0-1]))\\d{3}([0-9]||X)$")
                )
            {
                shenfenzheng1.Text = "*请输入有效身份证号";
                shenfenzheng1.Foreground = Brushes.Red;
                f5 = false;
            }
            else
            {
                shenfenzheng1.Foreground = Brushes.White;
                shenfenzheng1.Text = "";
                f5=true
                ;
            }
        }
        //手机号检测
        private void phnum_LostFocus(object sender, RoutedEventArgs e)
        {
            string num = phnum.Text.ToString();
            if(num.Length!=11||
                !Regex.IsMatch(num, @"^1(3[0-9]|4[57]|5[0-35-9]|7[0135678]|8[0-9])\d{8}$")
                )
            {
                phnum1.Text = "*请输入正确的手机号";
                phnum1.Foreground = Brushes.Red;
                f6 = false;
            }
            else
            {
                phnum1.Foreground = Brushes.White;
                phnum1.Text = "";
                f6 = true;
            }
        }
        //提交信息
       

        private void submit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {



            foucss.Focus();




            if (f1 && f2 && f3 && f4 && f5 && f6)
            {
                using(var v=new db.MyDb1())
                {
                    try
                    {
                        db.User user = new db.User()
                        {
                            Username = username.Text.ToString(),
                            jifen = 0,
                            IDCard = shenfenzheng.Text.ToString(),
                            name = nam.Text.ToString(),
                            password = pas.Password.ToString(),
                            Phonenum = phnum.Text.ToString(), money = 0
                           
                        };
                        db.Ticket ticket = new db.Ticket
                        {
                            time = "未知",
                            Username = username.Text.ToString()
                        };
                        v.User.Add(user);
                        v.Ticket.Add(ticket);
                        v.SaveChanges();
                        //MessageBox.Show("开户成功");
                        pp.Content = new Sucess(this,pp);
                        setInit();
                    }
                    catch
                    {
                        MessageBox.Show("开户失败");
                    }
                }
            }
        }
        private void setInit()
        {
            username.Text = "";
            pas.Password = "";
            rep_pas.Password = "";
            nam.Text = "";
            shenfenzheng.Text = "";
            phnum.Text = "";
            username1.Text = "*用户名由字母开头6-9位数字字母组合";
            pas1.Text = "*密码长度为8-15位";
            rep_pas1.Text = "*请再次输入密码";
            real_name.Text = "*请输入你的姓名";
            shenfenzheng1.Text = "*请输入18位身份证号";
            phnum1.Text = "*请输入11位手机号";
        }
    }
}

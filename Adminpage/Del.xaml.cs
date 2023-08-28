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
    /// Del.xaml 的交互逻辑
    /// </summary>
    public partial class Del : Page
    {
        Frame f;

        public Del(Frame ff)
         {
            f = ff;
            InitializeComponent();
        }
        public Del()
        {
           
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foucss.Focus();
            string user = username.Text.ToString();
            string pswrd = pass.Password.ToString();
            if (pswrd.Equals(""))
            {
                MessageBox.Show("请输入密码!");
                return;
            }
           
            using (var v = new db.MyDb1())
            {
                var q = from t in v.User
                        where t.Username.ToString().Equals(user) == true
                        select t;
                if (q.Count() == 0)
                {
                  
                    MessageBox.Show("用户名不存在!");
                    return;
                }
                var qq = from t in v.User
                         where t.Username.ToString().Equals(user) == true &&
                         t.password.ToString().Equals(pswrd) == true
                         select t;
                if (qq.Count() == 0)
                {
                    MessageBox.Show("密码错误!");
                    return;
                }
            }
           
           
            try
            {
                using(var v =new db.MyDb1())
                {
                    var q = from t in v.User
                            where t.Username.ToString().Equals(user) == true
                            select t;
                    foreach(var w in q)
                    {
                        v.User.Remove(w);
                    }
                    v.SaveChanges();
                    f.Content = new Sucess(this,f);
                    init();
                }
            }
            catch
            {
                MessageBox.Show("销户失败!");
            }
        }
        private void init()
        {
            username.Text = "";
            pass.Password = "";
        }
    }
}

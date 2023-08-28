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
    /// 充值.xaml 的交互逻辑
    /// </summary>
    public partial class 充值 : Page
    {
        Frame f;
        public 充值(Frame f)
        {
            this.f = f;
            InitializeComponent();
        }
        public 充值()
        {
            
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foucss.Focus();
            
            int mone = 0 ;
            try
            {
                mone = int.Parse(money.Text.ToString());
            }
            catch
            {              
                MessageBox.Show("请输入正确金额!");
                return;
            }

            using(var v =new db.MyDb1())
            {
                var q=from t in v.User
                      where t.Username.ToString().Equals(username.Text.ToString()) == true
                      select t;
                if (q.Count() == 0)
                {
                    
                    MessageBox.Show("用户名不存在!");
                    return;
                }
            }           
                try
                {
                    using (var v = new db.MyDb1())
                    {
                        var q = from t in v.User
                                where t.Username.ToString().Equals(username.Text.ToString()) == true
                                select t;
                        foreach (var w in q)
                        {
                            w.money += mone;
                        }
                        v.SaveChanges();
                    }
                f.Content = new Sucess(this,f);
                }catch
                {
                    MessageBox.Show("充值失败！");
                }
            
           
        }
    }
}

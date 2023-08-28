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
    /// query.xaml 的交互逻辑
    /// </summary>
    public partial class query : Page
    {
        public query()
        {
            InitializeComponent();
            border0.Visibility = Visibility.Hidden;
            border1.Visibility = Visibility.Hidden;
           
            border3.Visibility = Visibility.Hidden;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string use = username.Text.ToString();
            using(var v=new db.MyDb1())
            {
                var q = from t in v.User
                        where t.Username.ToString().Equals(use) == true
                        select t;
                if (q.Count() == 0)
                {

                    MessageBox.Show("用户名不存在!");
                    return;
                }
                else
                {
                   foreach(var w in q)
                    {
                        na.Text = w.name.ToString();
                        rest.Text = w.money.ToString();
                      
                    }
                    var qq = from t in v.Ticket
                             where t.Username.ToString().Equals(use) == true
                             select t;

                    foreach (var w in qq)
                    {
                        riqi.Text = w.time.ToString();
                        
                    }
                    border0.Visibility = Visibility.Visible;
                    border1.Visibility = Visibility.Visible;
                  
                    border3.Visibility = Visibility.Visible;
                    return;
                }
                
            }
        }
    }
}

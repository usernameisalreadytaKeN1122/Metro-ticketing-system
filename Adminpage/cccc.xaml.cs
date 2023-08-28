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
    /// cccc.xaml 的交互逻辑
    /// </summary>
    public partial class cccc : Page
    {
        public cccc()
        {
            InitializeComponent();
            using(var v =new db.MyDb1())
            {
                var q = from t in v.User
                        select t;
                d.ItemsSource = q.ToList();
              DateTime  dt = DateTime.Now;
                string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
                
                var qq = from t in v.Ticket
                         select t;
                dd.ItemsSource = qq.ToList();

            }
        }
    }
}

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
    /// Sucess.xaml 的交互逻辑
    /// </summary>
    public partial class Sucess : Page
    {
        Page p;
        Frame f;
        public Sucess(Page pp,Frame ff)
            
        {
            f = ff;
            p = pp;
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (p.Tag.ToString())
            {
                case "back":
                    f.Content = new backmima(f);
                    break;
                case "del":
                    f.Content = new Del(f);
                    break;
                case "open":
                    f.Content = new openAcount(f);
                    break;
                case "chongzhi":
                    f.Content = new 充值(f);
                    break;

            }
        }
    }
}

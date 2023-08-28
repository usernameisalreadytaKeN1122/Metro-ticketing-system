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
using System.Windows.Threading;
namespace 第二组综合设计地铁购票系统.VPage
{
    /// <summary>
    /// Payok.xaml 的交互逻辑
    /// </summary>
    public partial class Payok : Page
    {
        TicketInfo ticketS;
        string name;
        DispatcherTimer timer;
        private static int cnt;
        public Payok(TicketInfo ticket,string name)
        {
            cnt = 6;
            InitializeComponent();
            this.ticketS = ticket;
            this.name = name;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
            timer.Start();
            tic.Visibility = Visibility.Hidden;
            tt.Text = ticket.time;
            ss.Text = ticket.source;
            dd.Text = ticket.destination;
            using (var v=new db.MyDb1())
            {
                var q = from t in v.User
                        where t.Username.ToString().Equals(name) == true
                        select t;
                foreach(var w in q)
                {
                    w.money -= ticket.num_ticket * ticket.price;
                    
                }
                v.SaveChanges();
                var qq = from t in v.Ticket
                         where t.Username.ToString().Equals(name) == true
                         select t;
                foreach(var w in qq)
                {
                    w.time = ticket.final_time;
                }
                v.SaveChanges();
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cnt == 6)
            {
                wai.Text = "支付成功，正在出票. .    ";
                
            }
            if (cnt == 5)
            {
                wai.Text = "支付成功，正在出票. . .  ";
                
            }
            if (cnt == 4)
            {
                wai.Text = "支付成功，正在出票. . . .";
                
            }
            if (cnt == 3)
            {
                wai.Text = "支付成功，正在出票. .    ";
                
            }
            if (cnt == 2)
            {
                wai.Text = "支付成功，正在出票. . .  ";
                
            }
            if (cnt == 1)
            {
                wai.Text = "出票成功!";
                timer.Stop();
                tic.Visibility = Visibility.Visible;
                return;

            }
            cnt--;
        }
    }
}

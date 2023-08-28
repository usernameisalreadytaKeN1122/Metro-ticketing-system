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
    /// Pay.xaml 的交互逻辑
    /// </summary>
    public partial class Pay : Page
    {
        TicketInfo ticket;
        string username;
        DispatcherTimer timer;
        public Pay(TicketInfo ticket)
        {          
            InitializeComponent();
            this.username = MainWindow.username;
            this.ticket = ticket;
           
            time.Text = ticket.time;
            source.Text = ticket.source;
            dest.Text = ticket.destination;
            price.Text = ticket.price.ToString()+".0元";
            tic_num.Text = ticket.num_ticket.ToString()+"张";
            should_pay.Text = string.Format("{0}.0元", ticket.price * ticket.num_ticket);
            getInfo();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time.Text = ticket.time;
            source.Text = ticket.source;
            dest.Text = ticket.destination;
            price.Text = ticket.price.ToString() + ".0元";
            tic_num.Text = ticket.num_ticket.ToString() + "张";
            should_pay.Text = string.Format("{0}.0元", ticket.price * ticket.num_ticket);
            getInfo();
        }

        private void getInfo()
        {
            using(var v=new db.MyDb1())
            {
                var q = from t in v.User
                        where t.Username.ToString().Equals(username) == true
                        select t;
                if (q.Count() == 1)
                {
                    foreach(var w in q)
                    {
                        nnn.Text = w.name.ToString();
                        rrr.Text = w.money.ToString()+".0元";
                        later_pay.Text = string.Format("{0}.0元", w.money - ticket.price * ticket.num_ticket);
                        if (w.money - ticket.price * ticket.num_ticket < 0) ticket.canPay = false;
                        else ticket.canPay = true;
                    }
                }
            }
            
            
        }
    }
}

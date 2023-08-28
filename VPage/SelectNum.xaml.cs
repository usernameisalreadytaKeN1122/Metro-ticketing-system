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

namespace 第二组综合设计地铁购票系统.VPage
{
    /// <summary>
    /// SelectNum.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class SelectNum : Page
    {
        private TicketInfo ticket;
        SolidColorBrush[] brush = new SolidColorBrush[2];
        Border[] borders = new Border[8];
        System.Windows.Threading.DispatcherTimer timer;
        public SelectNum(TicketInfo ticket)
        {
            InitializeComponent();
            ticket.num_ticket = 1;
            this.ticket = ticket;
            titime.Text = ticket.time;
            source.Text = ticket.source;
            destin.Text = ticket.destination;
            tic_num .Text= ticket.num_ticket.ToString()+"张";
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Start();
            //计算票价 1元3站
           if(!MainPage.AllPath.conv)
                if (ticket.d_num % 3 != 0)
                {
                    ticket.price = ticket.d_num / 3 + 1;
                }
                else if (ticket.d_num % 3 == 0)
                {
                    ticket.price = ticket.d_num / 3;
                }
            

            price_.Text = string.Format("{0}.0元", ticket.price);
            brush[0] = new SolidColorBrush();

            brush[0].Color = Color.FromArgb(0xff,0x0e,0xf0,0x72);
            brush[1] = new SolidColorBrush();
            brush[1].Color = Color.FromArgb(0xff, 0x7a, 0xc7, 0x9c);
            borders[0] = a;
            borders[1] = b;
            borders[2] = c;
            borders[3] = d;
            borders[4] = e;
            borders[5] = f;
            borders[6] = g;
            borders[7] = h;


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            destin.Text = ticket.destination;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Border b = sender as Border;
                TextBlock text = b.Child as TextBlock;
                setColor(b);
                tic_num.Text = text.Text.ToString();
                ticket.num_ticket = int.Parse(b.Tag.ToString());

            }
            catch
            {

            }
        }
        private void setColor(Border b)
        {
            for(int i = 0; i < borders.Length; i++)
            {
                if (borders[i] == b)
                {
                    b.Background = brush[0];
                }
                else borders[i].Background = brush[1];
            }
        }
    }
}

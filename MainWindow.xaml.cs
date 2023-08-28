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
namespace 第二组综合设计地铁购票系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer_time;
        DateTime dt;
        private TicketInfo ticket;
        public static Page[] pages = new Page[5];
        DispatcherTimer timer;
        SolidColorBrush[] brushes = new SolidColorBrush[2];
        Border[] borderes = new Border[4];
        public static string username { get; set; }
        public MainWindow()
        {
            InitializeComponent();
           // this.username = username;
            ticket = new TicketInfo();
            pages[0] = new MainPage.AllPath(this.ticket, mainf);

            ticket.num_ticket = 1;

            lastbtn.Visibility = Visibility.Hidden;
            mainf.Content = pages[0];
            // pages[0].frames = mainf;
            //窗口大小设定
            double h = SystemParameters.PrimaryScreenHeight;
            double w = SystemParameters.PrimaryScreenWidth;
            this.Width = w * (6.0 / 7) * 0.85;
            this.Height = h * (8.0 / 9) * 0.85;
            timer_time = new System.Windows.Threading.DispatcherTimer();
            timer_time.Interval = TimeSpan.FromSeconds(1);
            timer_time.Tick += Timer_time_Tick;
            timer_time.Start();
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            time.Text = "Server Time: " + s + " CST";
            //计时器初始化
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();

            //设置颜色
            brushes[0] = new SolidColorBrush();
            brushes[0].Color = Color.FromArgb(0xff, 0x4d, 0x88, 0xff);
            brushes[1] = new SolidColorBrush();
            brushes[1].Color = Color.FromArgb(0xff, 0x4d, 0x60, 0x82);

            //设置边框
            borderes[0] = selectLine;
            borderes[1] = selectTicketNum;
            borderes[2] = pay;
            borderes[3] = paySucceed;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mainf.Content == pages[1])
            {
                lastbtn.Visibility = Visibility.Visible;
                setColor(borderes[1]);
            }
            else if (mainf.Content == pages[0])
            {
                lastbtn.Visibility = Visibility.Hidden;
                setColor(borderes[0]);
            }else if (mainf.Content == pages[2])
            {
                setColor(borderes[2]);
            }else if (mainf.Content == pages[3])
            {
                setColor(borderes[3]);
            }
        }

        private void Timer_time_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            time.Text = "Server Time: " + s + " CST";
        }

        //拖拽移动
        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {

            }
        }

        private void win_min_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void win_close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void win_min_MouseEnter(object sender, MouseEventArgs e)
        {
            Border bd = sender as Border;
            SolidColorBrush brush = new SolidColorBrush();

            brush.Color = Color.FromArgb(0xFF, 0x19, 0x88, 0x7e);
            bd.Background = brush;
        }

        private void win_min_MouseLeave(object sender, MouseEventArgs e)
        {
            Border bd = sender as Border;
            bd.Background = null;
        }

        private void nextbtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mainf.Content == pages[0])
            {

                if (ticket.isOK)
                {
                    pages[1] = new VPage.SelectNum(ticket);
                    mainf.Content = pages[1];
                }
                else
                {
                    MessageBox.Show("请选择车站!");
                    return;
                }
                MainPage.AllPath.conv = false; //说明此处不是快捷购票
            }
            else if (mainf.Content == pages[1])
            {
                pages[2] = new VPage.Pay(ticket);
                mainf.Content = pages[2];
            }else if (mainf.Content == pages[2])
            {
                if (ticket.canPay) pages[3] = new VPage.Payok(ticket,MainWindow.username);
                else pages[3] = new VPage.PayNo();
                mainf.Content = pages[3];
                next_text.Text = "返回";
                lastbtn.Visibility = Visibility.Hidden;
            }else if (next_text.Text.ToString().Equals("返回"))
            {
                ticket = new TicketInfo();
                pages[0] = new MainPage.AllPath(this.ticket, mainf);
                mainf.Content = pages[0];
                next_text.Text = "下一步";


            }
        }

        private void lastbtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mainf.Content == pages[1])
            {
                mainf.Content = pages[0];
                MainPage.AllPath.conv = false;
            }
            else if (mainf.Content == pages[2])
            {
                mainf.Content = pages[1];
                MainPage.AllPath.conv = false;
            }
        }
        /// <summary>
        /// 设置进度Border颜色
        /// </summary>
        /// <param name="b"></param>
        private void setColor(Border b)
        {
            for (int i = 0; i < borderes.Length; i++)
            {
                if (b == borderes[i]) borderes[i].Background = brushes[0];
                else borderes[i].Background = brushes[1];
            }
        }
    }
}

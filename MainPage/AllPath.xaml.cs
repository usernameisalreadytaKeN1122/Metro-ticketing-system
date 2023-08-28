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

namespace 第二组综合设计地铁购票系统.MainPage
{
    /// <summary>
    /// AllPath.xaml 的交互逻辑
    /// </summary>
    public partial class AllPath : Page
    {
       SolidColorBrush[] brush_qian = new SolidColorBrush[4];
        SolidColorBrush[] brush_shen = new SolidColorBrush[4];
        Border[] border = new Border[4];
        DispatcherTimer timer=new DispatcherTimer();
        public string source
        {
            set {
                sourcePoint.Text = value;
            }
            get
            {
                return sourcePoint.Text.ToString();
            }
        }
        public string dest
        {
            set
            {
                destinctionPoint.Text = value;
            }
            get
            {
                return destinctionPoint.Text.ToString();
            }
        }
        private TicketInfo ticket;
        DateTime dt;
        public Frame frames;
        public static Boolean conv;  //判断是不是快捷购票
        public AllPath(TicketInfo tickets,Frame f)
        {

            frames = f;
            //if (frames == null)
            //{
            //    MessageBox.Show("11111");
            //    return;
            //}
            this.ticket = tickets;
            
            InitializeComponent();
            fff.Content = new Path();
            //计时器初始化
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
            border[0] = allLineBtn;
            border[1] = line1Btn;
            border[2] = line2Btn;
            border[3] = line3Btn;
            ticket.isOK = false;
            brush_qian[0] = new SolidColorBrush();
            brush_qian[0].Color= Color.FromArgb(0xff, 0x7f, 0xbc, 0x8d);
            brush_shen[0] = new SolidColorBrush();
            brush_shen[0].Color= Color.FromArgb(0xff, 0x0f, 0xe5, 0x6e);

            brush_qian[1] = new SolidColorBrush();
            brush_qian[1].Color = Color.FromArgb(0xff, 0xf0, 0x64, 0x64);
            brush_shen[1] = new SolidColorBrush();
            brush_shen[1].Color = Color.FromArgb(0xff,0xf0,0x33,0x31);

            brush_qian[2] = new SolidColorBrush();
            brush_qian[2].Color = Color.FromArgb(0xff, 0xf4, 0xf4, 0xbb);
            brush_shen[2] = new SolidColorBrush();
            brush_shen[2].Color = Color.FromArgb(0xff, 0xe5, 0xf6, 0x21);

            brush_qian[3] = new SolidColorBrush();
            brush_qian[3].Color = Color.FromArgb(0xff, 0xe1, 0xca, 0xee);
            brush_shen[3] = new SolidColorBrush();
            brush_shen[3].Color = Color.FromArgb(0xff, 0xc9, 0x5a, 0xe2);
            conv = false;

        }
        /// <summary>
        /// 检查页面内容 设置 ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            string ss = string.Format("{0:yyyy-MM-dd}", dt);
            if (sourcePoint.Text.ToString().Equals("未选") == false && destinctionPoint.Text.ToString().Equals("未选") == false)
                ticket.isOK = true;
            ticket.final_time = s;
            ticket.time = ss;       

        }

        int flag = 0;

        private void allLineBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border a = sender as Border;
            switch (a.Name)
            {
                case "allLineBtn":
                    setback(a);
                    fff.Content = new Path();
                    destinctionPoint.Text = "未选";
                    sourcePoint.Text = "未选";
                    flag = 0;
                    break;
                case "line1Btn":
                    setback(a);
                    sourcePoint.Text = "河南工业大学";
                    destinctionPoint.Text = "未选";
                    ticket.source = "河南工业大学";
                    ticket.isOK = false;
                    flag = 1;
                    fff.Content = new Line_one(this,this.ticket);
                    break;
                case "line2Btn":
                    setback(a);
                    sourcePoint.Text = "刘庄";
                    destinctionPoint.Text = "未选";
                    ticket.source = "刘庄"; ticket.isOK = false;
                    fff.Content = new Line_twp(this, this.ticket);
                    flag = 2;
                    break;
                case "line3Btn":
                    setback(a);
                    sourcePoint.Text = "十八里河";
                    destinctionPoint.Text = "未选";
                    ticket.source = "十八里河"; ticket.isOK = false;
                    fff.Content = new Line_suburban(this, this.ticket);
                    flag = 3;
                    break;
            }
        }
        /// <summary>
        /// 设置背景
        /// </summary>
        /// <param name="a"></param>
        private void setback(Border a)
        {
            for(int i = 0; i < border.Length; i++)
            {
                if (a.Name.ToString().Equals(border[i].Name.ToString())){
                    border[i].Background = brush_shen[i];
                }
                else
                {
                    border[i].Background = brush_qian[i];
                }
            }
        }
       /// <summary>
       /// 快捷购票选择
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dt = DateTime.Now;
            string s = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
            string ss = string.Format("{0:yyyy-MM-dd}", dt);
            Border border = sender as Border;
            conv = true;
            switch (border.Tag.ToString())
            {
                case "two":
                    if (flag == 0)
                    {
                        MessageBox.Show("请选择路线!");
                        return;
                    }
                    ticket.source = sourcePoint.Text.ToString();
                    ticket.destination = "自本站起6站";
                    ticket.price = 2;
                    ticket.time = ss;
                    ticket.num_ticket = 1;
                    MainWindow.pages[1] = new VPage.SelectNum(ticket);
                    frames.Content = MainWindow.pages[1];
                    break;
                case "three":
                    if (flag == 0)
                    {
                        MessageBox.Show("请选择路线!");
                        return;
                    }
                    ticket.source = sourcePoint.Text.ToString();
                    ticket.destination = "自本站起9站";
                    ticket.price = 3;
                    ticket.time = ss;
                    ticket.num_ticket = 1;
                    MainWindow.pages[1] = new VPage.SelectNum(ticket);
                    frames.Content = MainWindow.pages[1];
                    break;
                case "four":
                    if (flag == 0)
                    {
                        MessageBox.Show("请选择路线!");
                        return;
                    }
                    ticket.source = sourcePoint.Text.ToString();
                    ticket.destination = "自本站起12站";
                    ticket.price = 4;
                    ticket.time = ss;
                    ticket.num_ticket = 1;
                    MainWindow.pages[1] = new VPage.SelectNum(ticket);
                    frames.Content = MainWindow.pages[1];
                    break;
                case "five":
                    if (flag == 0)
                    {
                        MessageBox.Show("请选择路线!");
                        return;
                    }
                    ticket.source = sourcePoint.Text.ToString();
                    ticket.destination = "自本站起15站";
                    ticket.price = 5;
                    ticket.time = ss;
                    ticket.num_ticket = 1;
                    MainWindow.pages[1] = new VPage.SelectNum(ticket);
                    frames.Content = MainWindow.pages[1];
                    break;
                case "six":
                    if (flag == 0)
                    {
                        MessageBox.Show("请选择路线!");
                        return;
                    }
                    ticket.source = sourcePoint.Text.ToString();
                    ticket.destination = "自本站起至终点站";
                    ticket.price = 6;
                    ticket.time = ss;
                    ticket.num_ticket = 1;
                    MainWindow.pages[1] = new VPage.SelectNum(ticket);
                    frames.Content = MainWindow.pages[1];
                    break;


            }
        }
    }
}

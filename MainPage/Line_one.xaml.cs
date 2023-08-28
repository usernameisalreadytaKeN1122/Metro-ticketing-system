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
    /// Line_one.xaml 的交互逻辑
    /// </summary>
    public partial class Line_one : Page
    {
        AllPath allPath;
        TicketInfo ticket;
        private Boolean sour;
        private Boolean dest;
        int sour_, dest_;
        DispatcherTimer timer;
        private SolidColorBrush[] brushes = new SolidColorBrush[3];//0为起点，1为终点 3,为默认
        public Line_one(AllPath allPath,TicketInfo ticket)
        {
            InitializeComponent();
            this.ticket = ticket;
            this.allPath = allPath;
           
            sour = dest = false;
            sour_ =-1; dest_ = -1;
            brushes[0] = new SolidColorBrush();

            brushes[0].Color = Color.FromArgb(0xff,0xf0,0x33,0x31);
            brushes[1] = new SolidColorBrush();
            brushes[1].Color = Color.FromArgb(0xff, 0x18, 0xba, 0x15);
            brushes[2] = new SolidColorBrush();
            brushes[2].Color = Color.FromArgb(0xff, 0xf0, 0x64, 0x64);
            sour = true;
            sour_ = 1;

            //计时器初始化
          
        }

        

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = null;
            TextBlock text = null;
           
            //按钮内容
            try
            {
                border = sender as Border;
                text = border.Child as TextBlock;
            }
            catch
            {

            }
            if (text.Text.ToString().Equals(allPath.dest) && dest)
            {
                allPath.dest = "未选";
                dest_ = -1;
                dest = !dest;
                ticket.destination = text.Text.ToString();
                border.Background = brushes[2];
                ticket.d_num = dest_ - sour_; //每次点击更新站数
               
                return;
            }

            if (!sour)
            {
                try
                {
                    sour_ = int.Parse(border.Tag.ToString());
                }

                catch
                {

                }

                if (sour_ >= dest_ && (sour_ != -1 && dest_ != -1))
                {
                    MessageBox.Show("请选择正确车站");
                    sour_ = -1;
                    return;
                }
                allPath.source = text.Text.ToString();
                sour = !sour;
                border.Background = brushes[0];
                ticket.d_num = dest_ - sour_; //每次点击更新站数
                ticket.source = text.Text.ToString();
               
                return;
            }

            if (text.Text.ToString().Equals(allPath.source) && sour)
            {
                allPath.source = "未选";
                sour_ = -1;
                sour = !sour;
                border.Background = brushes[2];
                ticket.d_num = dest_ - sour_; //每次点击更新站数
                ticket.source = text.Text.ToString();
                return;
            }

            if (!dest)
            {
                try
                {
                    dest_ = int.Parse(border.Tag.ToString());
                }
                catch
                {

                }

                if (dest_ <= sour_) //如果目的地错误
                {
                    MessageBox.Show("请选择正确车站");
                    dest_ = -1;
                    return;

                }

                allPath.dest = text.Text.ToString();
                dest = !dest;
                border.Background = brushes[1];
                ticket.d_num = dest_ - sour_; //每次点击更新站数
                ticket.destination = text.Text.ToString();
                return;
            }


        }
    }
}

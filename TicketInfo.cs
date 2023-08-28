using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第二组综合设计地铁购票系统
{
   public class TicketInfo
    {
        public string time { get; set; }//购票时间
        public string source { get; set; }//起始站
        public string destination { get; set; }//终点站
        public int num_ticket { get; set; }//票数
        public int price { get; set; }//单价
        public Boolean isOK { get; set; }
        public int d_num { get; set; }//站数
        public string final_time { get; set; }
        public bool canPay { get; set; }
    }
}

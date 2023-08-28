using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 第二组综合设计地铁购票系统.db
{
    class CheckInfo
    {
        //判断用户名是否重复
        public static Boolean checkUsername(String name)
        {
            try
            {
                using(var v =new MyDb1())
                {
                    var users = from t in v.User
                                where t.Username.ToString().Equals(name)==true
                                select t;
                    int u = users.Count();
                        if (u == 1)
                    {
                        return true;
                    }
                    //Console.WriteLine(u);
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return false;
        }
        //充值
        public static Boolean SetMoney(string name,int mone)
        {
            try
            {
                using(var v =new db.MyDb1())
                {
                    var q = from t in v.User
                            where t.Username.ToString().Equals(name) == true
                            select t;
                    foreach(var w in q)
                    {
                        w.money =11111;
                    }
                    v.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace 第二组综合设计地铁购票系统
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen s = new SplashScreen("8.jpg");
            s.Show(true);
            s.Close(new TimeSpan(0, 0, 13));
            base.OnStartup(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XDATA.Services;
using GalaSoft.MvvmLight.Threading;

namespace XDATA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Ioc.RegisterInheritedTypes(typeof(ServiceBase).Assembly, typeof(ServiceBase));
            SettingContext.Instance.Init();
            DispatcherHelper.Initialize(); //added

            base.OnStartup(e);
        }
    }
}

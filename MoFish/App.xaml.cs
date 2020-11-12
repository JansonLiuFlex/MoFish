using Autofac;
using MoFish.Core.Interfaces;
using MoFish.Core.IOC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MoFish
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var container = ConfigureServices();
            ServiceProvider.RegisterServiceLocator(container);
            var main = ServiceProvider.Get<IBaseWindow>("MainCenter");
            await main.ShowDialog();
        }


        private IContainer ConfigureServices()
        {
            //创建依赖容器
            ContainerBuilder builder = new ContainerBuilder();
            //注册日志服务
            //builder.RegisterType<ConsumptionNLog>().As<ILog>().SingleInstance();
            ////注册HTTP服务依赖关系
            //builder.AddCustomRepository<UserService, IUserRepository>()
            //    .AddCustomRepository<GroupService, IGroupRepository>()
            //    .AddCustomRepository<MenuService, IMenuRepository>()
            //    .AddCustomRepository<BasicService, IBasicRepository>();
            ////注册ViewModel依赖关系
            //builder.AddCustomViewModel<UserViewModel, IUserViewModel>()
            //    .AddCustomViewModel<GroupViewModel, IGroupViewModel>()
            //    .AddCustomViewModel<MenuViewModel, IMenuViewModel>()
            //    .AddCustomViewModel<BasicViewModel, IBasicViewModel>();

            //注册程序集
            var assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();
            foreach (var t in types)
            {
                //简陋判断一下,一般而言,该定义仅仅注册Center结尾的类依赖关系。
                if (t.Name.EndsWith("Center"))
                {
                    var firstInterface = t.GetInterfaces().FirstOrDefault();
                    if (firstInterface != null)
                        builder.RegisterType(t).Named(t.Name, firstInterface);
                }
            }
            return builder.Build();
        }
    }
}

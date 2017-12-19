using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Xmu.Crms.Shared;

namespace Xmu.Crms.Group1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //添加自身的RESTful API
            //将RESTful API放在这个项目（如 ClassController.cs）
            Startup.ControllerAssembly.Add(Assembly.GetEntryAssembly());

            //添加所需要的界面
            Startup.ControllerAssembly.Add(Assembly.GetAssembly(typeof(Xmu.Crms.Web.Group1.Program)));

            //添加所需要的Service
            Startup.ConfigureCrmsServices += collection => collection.AddGroup1UserService();

            var host = BuildWebHost(args);
            host.Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
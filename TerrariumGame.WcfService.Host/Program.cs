using Autofac;
using Autofac.Core;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.WcfInterfaces.Services;
using TerrariumGame.WcfServices;

namespace TerrariumGame.WcfService.Host
{
    class Program
    {
        private static IContainer Container { get; set; }
        private const string JSON_FILE_NAME = "Configs/autofacConfig.json";

        static void Main(string[] args)
        {
            Container = AutofacBuilder.ConfigByJson(JSON_FILE_NAME);

            //using (ServiceHost host = new ServiceHost(typeof(WcfConversationService)))
            //{
            //    host.AddDependencyInjectionBehavior<IWcfConversationService>(Container);           

            //    host.Open();

            //    Console.WriteLine("Service hosted successfully");

            //    Console.ReadKey(true);
            //}

            ServiceHost host = new ServiceHost(typeof(WcfConversationService));

            host.AddDependencyInjectionBehavior<IWcfConversationService>(Container);

            host.Open();
            foreach (var item in host.BaseAddresses)
            {
                Console.WriteLine(item.AbsoluteUri);
            }
            Console.WriteLine("Service hosted successfully");

            Console.ReadKey(true);

        }
    }
}

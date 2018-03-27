using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.WcfServices;

namespace TerrariumGame.WcfService.Host
{
    class Program
    {
        private static IContainer Container { get; set; }
        private const string JSON_FILE_NAME = "Configs/autofacConfig.json";
        private const string XML_FILE_NAME = "Configs/autofacConfig.xml";

        static void Main(string[] args)
        {
            Container = AutofacBuilder.ConfigByJson(JSON_FILE_NAME);

            //using (ServiceHost host = new ServiceHost(typeof(WcfConversationService)))
            //{
            //    // Container = AutofacBuilder.ConfigByXml(XML_FILE_NAME);
            //    host.Open();
            //    Console.WriteLine("Service hosted successfully");
            //}
            //Console.ReadKey(true);
        }
    }
}

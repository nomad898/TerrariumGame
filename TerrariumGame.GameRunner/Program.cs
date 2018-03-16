using Autofac;
using BusinessLibrary.Clients;
using InterfaceLibrary.Interfaces;
using System;

namespace TerrariumGame.GameRunner
{
    class Program
    {
        private static IContainer Container { get; set; }
        private const string JSON_FILE_NAME = "Configs/autofacConfig.json";
        private const string XML_FILE_NAME = "Configs/autofacConfig.xml";

        static void Main(string[] args)
        {
            // WebApiClient           

            ////Container = AutofacBuilder.Build();
            ////Container = AutofacBuilder.ConfigByJson(JSON_FILE_NAME);
            ////// Container = AutofacBuilder.ConfigByXml(XML_FILE_NAME);
            ////Run(Container);
            WcfClient client = new WcfClient();
            var list = client.Get();
            foreach (var item in list)
            {
                Console.WriteLine(item.Message);
            }
            Console.ReadKey(true);
        }

        private static void Run(IContainer container)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGame>();
                game.Start(false);
            }
        }
    }
}

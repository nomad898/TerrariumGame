using Autofac;
using BusinessInterfaces.Clients;
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
            //for (int i = 0; i <= 20; i++)
            //{
            //    IWebApiClient webApiClient = new WebApiClient();
            //    webApiClient.CreateConversationAsync("Simple");
            //}
            // Console.ReadKey();
            Container = AutofacBuilder.Build();
            Container = AutofacBuilder.ConfigByJson(JSON_FILE_NAME);
            // Container = AutofacBuilder.ConfigByXml(XML_FILE_NAME);
            Run(Container);
            Console.ReadKey(true);
        }

        private static void Run(IContainer container)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGame>();
                game.Start();
            }
        }       
    }
}

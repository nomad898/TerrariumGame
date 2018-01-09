using Autofac;
using Autofac.Configuration;
using InterfaceLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace GameRunner
{
    class Program
    {
        private static IContainer Container { get; set; }
        private const string JSON_FILE_NAME = "autofac.json";
        private const string XML_FILE_NAME = "autofacConfig.xml";

        static void Main(string[] args)
        {              
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

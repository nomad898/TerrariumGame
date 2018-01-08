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

        static void Main(string[] args)
        {        
            Container = AutofacBuilder.ConfigByXml();
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

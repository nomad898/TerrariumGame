using Autofac;
using Autofac.Configuration;
using InterfaceLibrary.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;

namespace GameRunner
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {        
            Container = AutofacBuilder.ConfigByJson();
            Run(Container);            
            Console.ReadKey(true);
        }

        private static int Run(IContainer container)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var game = scope.Resolve<IGame>();
                game.Start();
                var map = scope.Resolve<IMap>();
                return map.Height;
            }
        }

    }
}

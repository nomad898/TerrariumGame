using Autofac;
using InterfaceLibrary.Interfaces;
using System;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;

namespace ConsoleApplication
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        { 
            Container = AutofacBuilder.Build();
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

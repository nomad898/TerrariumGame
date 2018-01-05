using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTraining
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            Container = builder.Build();
            WriteDate();         

            Console.ReadKey(true);
        }

        private static void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
    }
}

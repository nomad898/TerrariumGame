using Autofac;
using InterfaceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Infrastructure;
using TerrariumGame.Infrastructure.Factory;

namespace ConsoleApplication
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Map>().As<IMap>();
            builder.RegisterType<GameObjectFactory>().As<IGameObjectFactory>();
            builder.RegisterType<MapManipulator>().As<IMapManipulator>();
            builder.RegisterType<Dice>().As<IDice>();
            builder.RegisterType<Game>().As<IGame>();

            return builder.Build();
        }
    }
}

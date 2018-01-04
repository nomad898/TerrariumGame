using Autofac;
using Autofac.Core;
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
            // This is works, but should i use it?
            //builder.Register(m => new Map(10, 10))
            //    .As<IMap>();
            builder.RegisterType<Map>().As<IMap>().SingleInstance();
            builder.RegisterType<Dice>().As<IDice>().SingleInstance();
            builder.RegisterType<GameObjectFactory>().As<IGameObjectFactory>().SingleInstance();
            builder.RegisterType<MapManipulator>().As<IMapManipulator>().SingleInstance();            
            builder.RegisterType<Game>().As<IGame>().SingleInstance();

            return builder.Build();
        }
    }
}

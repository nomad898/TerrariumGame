using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace Terrarium.GameRunner
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            //REFERENCE DELETED!!!
            //This is works, but should i use it?
            //builder.Register(m => new Map(10, 10))
            //    .As<IMap>();
            //builder.RegisterType<Map>().As<IMap>().SingleInstance();
            //builder.RegisterType<Dice>().As<IDice>().SingleInstance();
            //builder.RegisterType<GameObjectFactory>().As<IGameObjectFactory>().SingleInstance();
            //builder.RegisterType<MapManipulator>().As<IMapManipulator>().SingleInstance();       
            //builder.RegisterType<ConsoleMessageWriter>().As<IMessageWriter>().SingleInstance();
            //builder.RegisterType<Game>().As<IGame>().SingleInstance();
            return builder.Build();
        }

        public static IContainer ConfigByJson(string jsonFileName)
        {           
            var config = new ConfigurationBuilder();
            config.AddJsonFile(jsonFileName);
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            return builder.Build();
        }

        public static IContainer ConfigByXml(string xmlFileName)
        {
            var builder = new ContainerBuilder();
            var config = new ConfigurationBuilder();
            config.AddXmlFile(xmlFileName);
            var module = new ConfigurationModule(config.Build());            
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}

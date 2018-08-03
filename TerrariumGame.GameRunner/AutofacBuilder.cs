using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TerrariumGame.GameRunner.Utility;

namespace TerrariumGame.GameRunner
{
    class AutofacBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();
            return builder.Build();
        }

        //TODO Change Automapper injection
        public static IContainer ConfigByJson(string jsonFileName)
        {           
            var config = new ConfigurationBuilder();
            config.AddJsonFile(jsonFileName);
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            builder.RegisterInstance<IMapper>(mapper);
            builder.RegisterModule(module);
            return builder.Build();
        }

        // TODO Doesn't work because has no Automapper.
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

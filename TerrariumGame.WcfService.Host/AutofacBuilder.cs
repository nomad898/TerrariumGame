using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace TerrariumGame.WcfService.Host
{
    class AutofacBuilder
    {
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
            // config.AddXmlFile(xmlFileName);
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}

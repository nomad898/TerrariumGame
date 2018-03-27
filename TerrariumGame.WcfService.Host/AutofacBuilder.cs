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
    }
}

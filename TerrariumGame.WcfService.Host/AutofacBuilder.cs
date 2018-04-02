using Autofac;
using Autofac.Configuration;
using Autofac.Configuration.Core;
using Microsoft.Extensions.Configuration;
using TerrariumGame.WcfInterfaces.Services;
using TerrariumGame.WcfServices;

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
            builder.RegisterType<WcfConversationService>().As<IWcfConversationService>();
            builder.RegisterModule(module);
            return builder.Build();
        }        
    }
}

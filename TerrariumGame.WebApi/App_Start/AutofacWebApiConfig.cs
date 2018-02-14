using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using BusinessInterfaces.Services;
using BusinessLibrary.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Web.Http;

namespace TerrariumGame.WebApi.App_Start
{
    public class AutofacWebApiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            var cfg = new ConfigurationBuilder();
            cfg.AddJsonFile("config.json");

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ConversationService>().As<IConversationService>().InstancePerRequest();

          
            var module = new ConfigurationModule(cfg.Build());
            builder.RegisterModule(module);

            Container = builder.Build();

            return Container;
        }
    }
}
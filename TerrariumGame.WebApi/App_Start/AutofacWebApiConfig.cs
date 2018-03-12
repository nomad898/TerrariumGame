using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using AutoMapper;
using BusinessInterfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Web.Http;
using TerrariumGame.WebApi.Utility.Automapper;

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

            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            cfg.AddJsonFile("config.json");

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
               
            var module = new ConfigurationModule(cfg.Build());
            builder.RegisterModule(module);
            builder.RegisterInstance<IMapper>(mapper);

            Container = builder.Build();
            return Container;
        }
    }
}
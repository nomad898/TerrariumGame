using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerrariumGame.WcfServiceApp
{
    public class AutofacBuilder
    {
        public static IContainer ConfigByJson(string jsonFileName)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile(jsonFileName);
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            builder.RegisterType<ConversationWcfService>().InstancePerLifetimeScope();
            builder.RegisterInstance<IMapper>(mapper);
            return builder.Build();
        }
    }
}
using Autofac;
using BusinessInterfaces.Services;
using BusinessLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TerrariumGame.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConversationService>().As<IConversationService>().InstancePerRequest();
            var config = GlobalConfiguration.Configuration;
          
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

using Autofac;
using BusinessInterfaces.Services;
using BusinessLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TerrariumGame.WebApi.App_Start;

namespace TerrariumGame.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Run();   
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

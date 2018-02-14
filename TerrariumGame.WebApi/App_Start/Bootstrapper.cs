using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TerrariumGame.WebApi.App_Start;

namespace TerrariumGame.WebApi.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
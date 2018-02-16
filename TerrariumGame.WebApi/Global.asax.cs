using System.Web;
using System.Web.Http;
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

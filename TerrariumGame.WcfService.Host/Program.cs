using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.WcfServices;
using TerrariumGame.WcfServices.Services;

namespace TerrariumGame.WcfService.Host
{
    class Program

    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WcfConversationService));
            host.Open();
            Console.WriteLine("Service hosted successfully");
            Console.ReadKey(true);
        }
    }
}

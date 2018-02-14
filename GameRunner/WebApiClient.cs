using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumGame.GameRunner
{
    public class WebApiClient
    {
        public void GetAllConversations()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:50808/api/Value");
                Console.WriteLine(Environment.NewLine + result);
                Console.ReadKey();
            }
        }
    }
}

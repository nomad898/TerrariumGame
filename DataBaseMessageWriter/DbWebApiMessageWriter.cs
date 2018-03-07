using BusinessInterfaces.Clients;
using InterfaceLibrary.Interfaces.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageWriter
{
    public class DbWebApiMessageWriter : IMessageWriter
    {
        private readonly IWebApiClient webApiClient;

        public DbWebApiMessageWriter(IWebApiClient client)
        {
            webApiClient = client;
        }

        public void PrintMessage(string message)
        {
            if (message != string.Empty)
            {
                webApiClient.CreateConversationAsync(message);
            }
        }
    }
}

using InterfaceLibrary.Interfaces.Writer;
using BusinessInterfaces.Clients;
using System.Threading.Tasks;

namespace MessageWriter
{
    class DataBaseMessageWriter : IMessageWriter
    {
        private readonly IWebApiClient webApiClient;
        
        public DataBaseMessageWriter(IWebApiClient webApiClient)
        {
            this.webApiClient = webApiClient;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            webApiClient.CreateConversationAsync(message);
        }
        #endregion
    }
}

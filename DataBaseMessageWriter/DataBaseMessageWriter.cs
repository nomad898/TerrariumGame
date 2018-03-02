using InterfaceLibrary.Interfaces.Writer;
using BusinessInterfaces.Clients;

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
            webApiClient.CreateConversation();
        }
        #endregion
    }
}

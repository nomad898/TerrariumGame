using ClientInterfaces.Clients;
using InterfaceLibrary.Interfaces.Writer;

namespace MessageWriter
{
    public class DbApiMessageWriter : IMessageWriter
    {
        private readonly IClient client;

        public DbApiMessageWriter(IClient client)
        {
            this.client = client;
        }

        public void PrintMessage(string message)
        {
            if (message != string.Empty)
            {
                client.CreateConversationAsync(message);
            }
        }
    }
}

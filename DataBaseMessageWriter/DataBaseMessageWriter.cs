using InterfaceLibrary.Interfaces.Writer;
using BusinessInterfaces.Clients;
using BusinessInterfaces.Services;

namespace MessageWriter
{
    class DataBaseMessageWriter : IMessageWriter
    {
        private readonly IConversationService conversationService;
        
        public DataBaseMessageWriter(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            if (message != string.Empty)
            {
                conversationService.WriteMessage(message);
            }
        }
        #endregion
    }
}

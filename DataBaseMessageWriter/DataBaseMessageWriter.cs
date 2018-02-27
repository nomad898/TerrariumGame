using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using BusinessInterfaces.Services;

namespace MessageWriter
{
    class DataBaseMessageWriter : IMessageWriter
    {
        private IConversationService conversationService;

        public DataBaseMessageWriter(IConversationService convSerive)
        {
            this.conversationService = convSerive;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            throw new System.Exception();
        }

        public void PrintMessage(string message, MessageType msgType)
        {
            if (msgType == MessageType.ConversationMsg
                && message != string.Empty)
            {
                PrintMessage(message);
            }
        }
        #endregion
    }
}

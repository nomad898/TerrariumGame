using System;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using DataBaseInterfaces.Entities;
using DataBaseMessageWriter;
using DataBaseInterfaces.Repositories;

namespace MessageWriter
{
    public class DataBaseMessageWriter : IMessageWriter
    {
        private IConversationRepository conversationRepo;

        public DataBaseMessageWriter(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            IConversation c = new ConversationDto
            {
                Message = message,
                Date = DateTime.Now
            };
            conversationRepo.Create(c);
            conversationRepo.Save();
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

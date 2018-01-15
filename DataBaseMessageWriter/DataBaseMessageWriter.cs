using System;
using DataBaseInterfaces;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using DataBaseInterfaces.Entities;
using DataBaseMessageWriter;

namespace MessageWriter
{
    public class DataBaseMessageWriter : IMessageWriter
    {
        private IUnitOfWork uow;

        public DataBaseMessageWriter(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        #region IMessageWriter
        public void PrintMessage(string message)
        {
            IConversation conv = new ConversationDto
            {
                Message = message,
                Date = DateTime.Now
            };
            uow.ConversationRepository.Create(conv);
            uow.Save();
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

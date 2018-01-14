using System;
using DataBaseInterfaces;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;

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
            Conversation conv = new Conversation()
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

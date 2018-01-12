using System;
using InterfaceLibrary.Interfaces.Writer;
using InterfaceLibrary.UtilityModels;
using InterfaceLibrary.Interfaces.Repository;
using DataBaseMessageWriter.Repositories;
using DataBaseMessageWriter.Entities;

namespace MessageWriter
{
    public class DataBaseMessageWriter : IMessageWriter
    {
        private UnitOfWork uow;

        public DataBaseMessageWriter()
        {
            this.uow = new UnitOfWork();
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

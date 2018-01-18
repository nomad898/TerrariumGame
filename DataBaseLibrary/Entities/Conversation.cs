using DataBaseInterfaces.Entities;
using System;

namespace DataBaseLibrary.Entities
{
    class Conversation : IConversation
    {
        public virtual int ConversationId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Message { get; set; }

        public void TransferData(IConversation entity)
        {
            Date = entity.Date;
            Message = entity.Message;
        }
    }
}

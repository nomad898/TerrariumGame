using System;

namespace DataBaseInterfaces.Entities
{
    public interface IConversation
    {
        int ConversationId { get; set; }
        DateTime Date { get; set; }
        string Message { get; set; }

        void TransferData(IConversation entity);
    }
}

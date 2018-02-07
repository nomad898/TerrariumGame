using BusinessInterfaces.DTO;
using DataBaseInterfaces.Entities;
using System;

namespace BusinessLibrary.DTO
{
    class ConversationDto : IConversationDto
    {
        public int ConversationId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public void TransferData(IConversation entity)
        {
            Date = entity.Date;
            Message = entity.Message;
        }
    }
}

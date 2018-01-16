using DataBaseInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMessageWriter
{
    class ConversationDto : IConversation
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

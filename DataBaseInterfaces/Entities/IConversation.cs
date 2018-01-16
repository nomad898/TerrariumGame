using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

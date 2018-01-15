using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterfaces.Entity
{
    public interface IConversation
    {
        int ConversationId { get; set; }
        DateTime Date { get; set; }
        string Message { get; set; }
    }
}

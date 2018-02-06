using DataBaseInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<IConversation>
    {
        void WriteMessage(string message);
    }
}

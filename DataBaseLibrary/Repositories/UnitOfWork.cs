using DataBaseInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private ConversationRepository conversationRepository;

        public IConversationRepository ConversationRepository
        {
            get
            {
                return conversationRepository;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

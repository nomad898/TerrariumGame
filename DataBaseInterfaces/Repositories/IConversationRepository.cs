using DataBaseInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterfaces.Repositories
{
    public interface IConversationRepository<TEntity> : IRepository<TEntity, int> 
        where TEntity : IConversation
    {
    }
}

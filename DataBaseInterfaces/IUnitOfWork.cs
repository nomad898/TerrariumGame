using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using System;

namespace DataBaseInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IConversationRepository ConversationRepository { get; }
    }
}

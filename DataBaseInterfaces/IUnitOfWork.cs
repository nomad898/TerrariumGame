﻿using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace DataBaseInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        
        IConversationRepository<IConversation> ConversationRepository { get; }
    }
}

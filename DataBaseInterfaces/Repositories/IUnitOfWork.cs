﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseInterfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IConversationRepository ConversationRepository { get; }

        void Save();
    }
}
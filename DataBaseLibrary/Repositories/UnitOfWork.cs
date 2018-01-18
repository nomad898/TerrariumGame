using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext db;

        public UnitOfWork(IConversationRepository conversationRepository)
        {
            db = new DataBaseContext();
            this.conversationRepository = conversationRepository;
        }

        public UnitOfWork(DataBaseContext context,
            IConversationRepository conversationRepository)
        {
            db = context;
            this.conversationRepository = conversationRepository;
        }

        private IConversationRepository conversationRepository;
        public IConversationRepository ConversationRepository
        {
            get
            {
                return conversationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                db.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion      
    }
}

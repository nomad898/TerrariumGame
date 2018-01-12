using DataBaseMessageWriter.EF;
using InterfaceLibrary.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMessageWriter.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private DataBaseContext db;
        private ConversationRepository conversationRepository;
        
        public UnitOfWork()
        {
            db = new DataBaseContext();
        }

        public ConversationRepository ConversationRepository
        {
            get
            {
                if (conversationRepository == null)
                {
                    conversationRepository = new ConversationRepository(db);
                }
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

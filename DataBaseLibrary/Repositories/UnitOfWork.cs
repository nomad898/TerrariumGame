using DataBaseInterfaces;
using DataBaseLibrary.EFContext;
using System;
using DataBaseInterfaces.Repositories;
using System.Threading.Tasks;
using DataBaseInterfaces.Entities;

namespace DataBaseLibrary.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext db;       

        public UnitOfWork()
        {
            db = new DataBaseContext();
        }

        public UnitOfWork(DataBaseContext context)
        {
            db = context;       
        }

        private IConversationRepository<IConversation> conversationRepository;

        public IConversationRepository<IConversation> ConversationRepository
        {
            get
            {
                if (conversationRepository == null)
                    conversationRepository = new ConversationRepository(db);
                return conversationRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
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

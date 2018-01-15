﻿using DataBaseInterfaces;
using DataBaseLibrary.EFContext;
using System;
using DataBaseInterfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext db;       

        public UnitOfWork(DataBaseContext context)
        {
            db = context;       
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

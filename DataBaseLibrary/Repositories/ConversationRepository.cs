using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using DataBaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataBaseLibrary.Repositories
{
    class ConversationRepository : IConversationRepository<Conversation, int>
    {
        private DataBaseContext db;

        public ConversationRepository(DataBaseContext context)
        {
            db = context;
        }

        public void Create(Conversation item)
        {
            db.Conversations.Add(item);
        }

        public void DeleteById(int id)
        {
            Conversation conversation = FindById(id);
            if (conversation != null)
            {
                db.Conversations.Remove(conversation);
            }
        }

        public Conversation FindById(int id)
        {
            Conversation conversation = db.Conversations.Find(id);
            if (conversation != null)
            {
                return conversation;
            }
            else
            {
                string errMsg = string
                    .Format("Can't find {0} with id {1}", GetType(), id);
                throw new NullReferenceException(errMsg);
            }
        }

        public IEnumerable<Conversation> GetAll()
        {
            return db.Conversations;
        }

        public void Update(Conversation item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

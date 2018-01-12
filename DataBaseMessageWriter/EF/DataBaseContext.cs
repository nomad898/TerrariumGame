using DataBaseMessageWriter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMessageWriter.EF
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("Conversations")
        {

        }

        public DbSet<Conversation> Conversations { get; set; }
    }
}

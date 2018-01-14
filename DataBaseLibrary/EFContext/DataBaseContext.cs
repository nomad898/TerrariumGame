using DataBaseLibrary.Entities;
using System.Data.Entity;

namespace DataBaseLibrary.EFContext
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("TerrariumDB")
        {

        }

        public DbSet<Conversation> Conversations { get; set; }
    }
}

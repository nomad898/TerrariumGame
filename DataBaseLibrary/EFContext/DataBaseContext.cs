using DataBaseInterfaces.Entity;
using DataBaseLibrary.Entities;
using System.Data.Entity;

namespace DataBaseLibrary.EFContext
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("TerrariumDB")
        {

        }

        public DbSet<IConversation> Conversations { get; set; }
    }
}

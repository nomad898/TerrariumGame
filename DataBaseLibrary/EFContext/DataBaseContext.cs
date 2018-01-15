using DataBaseInterfaces.Entities;
using DataBaseLibrary.Entities;
using System.Data.Entity;

namespace DataBaseLibrary.EFContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("TerrariumDB")
        {

        }

        public DbSet<Conversation> Conversations { get; set; }
    }
}

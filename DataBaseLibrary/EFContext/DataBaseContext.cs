using DataBaseInterfaces.Entities;
using DataBaseLibrary.Entities;
using System.Data.Common;
using System.Data.Entity;

namespace DataBaseLibrary.EFContext
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("TerrariumDB")
        {
        }

        public DataBaseContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        ///     This Constructor is used in tests
        /// </summary>
        /// <param name="connection"></param>
        public DataBaseContext(DbConnection connection) 
            : base(connection, true)
        {
        }

        public virtual IDbSet<Conversation> Conversations { get; set; }
    }
}

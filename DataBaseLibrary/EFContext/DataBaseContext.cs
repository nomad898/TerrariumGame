using System.Data.Common;
using System.Data.Entity;
using TerrariumGame.Model.Entities;

namespace DataBaseLibrary.EFContext
{
    public class DataBaseContext : DbContext
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>().ToTable("Conversations");
            modelBuilder.Entity<Conversation>().HasKey(c => c.ConversationId);
            modelBuilder.Entity<Conversation>().Property(c => c.Date).HasColumnName("DateTime");
            modelBuilder.Entity<Conversation>().Property(c => c.Message).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}

using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        private static readonly string DefaultConnectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryDB.mdf;Integrated Security=True";
        public DBContext() : base("name=LibraryDB")
        {
        }

        public DBContext(string connectionString) : base(connectionString ?? DefaultConnectionString)
        {
        }

        public DbSet<Labubu> Labubus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labubu>().ToTable("Labubus");
            base.OnModelCreating(modelBuilder);
        }
    }
}
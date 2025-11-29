using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=LibraryDB")  
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

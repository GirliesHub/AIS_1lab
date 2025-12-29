using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        //private static readonly string DefaultConnectionString =
        //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryDB.mdf;Integrated Security=True";
        //public DBContext() : base("name=LibraryDB")
        //{
        //}

        //public DBContext(string connectionString) : base(connectionString ?? DefaultConnectionString)
        //{
        //}

        //public DbSet<Labubu> Labubus { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Labubu>().ToTable("Labubus");
        //    base.OnModelCreating(modelBuilder);
        //}

        public DBContext() : base("LibraryDB") { }
        public DBContext(string connectionString) : base(connectionString ?? "LibraryDB") { }

        public DbSet<Labubu> Labubus { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<LabubuCollector> LabubuCollectors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labubu>().ToTable("Labubus");
            modelBuilder.Entity<Collector>().ToTable("Collectors");
            modelBuilder.Entity<LabubuCollector>().ToTable("LabubuCollectors");
            modelBuilder.Entity<LabubuCollector>()
                .HasKey(lc => new { lc.LabubuId, lc.CollectorId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
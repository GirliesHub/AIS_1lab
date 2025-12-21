using LabubuModel;
using System.Data.Entity;
using Shared;


namespace Model.DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DefaultConnection")
        {
            // Автоматически создает БД если её нет
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
        }

        // Конструктор с connectionString (для Dapper)
        public DBContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DBContext>());
        }

        public DbSet<Labubu> Labubus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labubu>().ToTable("Labubus");
            base.OnModelCreating(modelBuilder);
        }
    }
}
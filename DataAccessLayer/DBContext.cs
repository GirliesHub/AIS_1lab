using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {

        /// <summary>
        /// Строка подключения по умолчанию к LabubuDB.mdf
        /// </summary>
        private static readonly string DefaultConnectionString =
            $@"Data Source=(localdb)\MSSQLLocalDB;
               AttachDbFilename={Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\LabubuDB.mdf")};
               Integrated Security=True;
               Connect Timeout=30;";

        /// <summary>
        /// Конструктор по умолчанию – использует DefaultConnectionString
        /// </summary>
        public DBContext()
            : base(DefaultConnectionString)
        {
        }

        /// <summary>
        /// Конструктор с явной строкой подключения 
        /// </summary>
        public DBContext(string connectionString)
            : base(string.IsNullOrWhiteSpace(connectionString) ? DefaultConnectionString : connectionString)
        {
        }


        /// <summary>
        /// Набор сущностей Labubu, отображаемых на таблицу Labubus.
        /// </summary>
        public DbSet<Labubu> Labubus { get; set; }

        /// <summary>
        /// Конфигурирует отображение сущностей на таблицы базы данных.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labubu>().ToTable("Labubus");

            base.OnModelCreating(modelBuilder);
        }
    }
}

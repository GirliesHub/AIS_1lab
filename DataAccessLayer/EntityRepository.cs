using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// EF репозиторий для доменных сущностей
    /// </summary>
    public class EntityRepository<T> : IRepository<T>, IDisposable
        where T : class, IDomainObject
    {
        private readonly DBContext _context;

        /// <summary>
        /// Конструктор по умолчанию (использует стандартную строку подключения DBContext)
        /// </summary>
        public EntityRepository()
            : this(CreateDbContext())
        {
        }

        /// <summary>
        /// Конструктор с готовым контекстом (для DI / тестов)
        /// </summary>
        public EntityRepository(DBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Старый конструктор со строкой подключения (на всяк)
        /// </summary>
        public EntityRepository(string connectionString)
            : this(new DBContext(connectionString))
        {
        }

        /// <summary>
        /// Создаёт и возвращает новый экземпляр DBContext с кастомной строкой подключения
        /// </summary>
        private static DBContext CreateDbContext()
        {
            var dbPath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\LabubuDB.mdf");
            var connectionString =
                $@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";

            return new DBContext(connectionString);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var existing = _context.Set<T>().Find(entity.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}

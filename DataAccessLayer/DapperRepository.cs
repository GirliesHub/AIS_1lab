using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;
using System.Data;
using System.Data.Common;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction? _transaction;
        private readonly string _tableName;

        // Конструктор для обычного использования (без транзакции)
        public DapperRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _transaction = null;
            _tableName = typeof(T).Name + "s";
        }

        // Конструктор для UnitOfWork (с транзакцией)
        public DapperRepository(IDbConnection connection, IDbTransaction? transaction = null)
        {
            _connection = connection;
            _transaction = transaction;
            _tableName = typeof(T).Name + "s";
        }

        public IEnumerable<T> GetAll()
        {
            return _connection.Query<T>($"SELECT * FROM {_tableName}", transaction: _transaction);
        }

        public T? Get(int id)
        {
            return _connection.QuerySingleOrDefault<T>(
                $"SELECT * FROM {_tableName} WHERE ID = @ID",
                new { ID = id },
                transaction: _transaction);
        }

        public void Create(T entity)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "ID" && p.CanRead && p.CanWrite);

            var columns = string.Join(",", properties.Select(p => p.Name));
            var parameters = string.Join(",", properties.Select(p => "@" + p.Name));

            var sql = $"INSERT INTO {_tableName} ({columns}) VALUES ({parameters}); SELECT CAST(SCOPE_IDENTITY() as int)";

            entity.ID = _connection.QuerySingle<int>(sql, entity, transaction: _transaction);
        }

        public void Update(T entity)
        {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "ID" && p.CanRead && p.CanWrite);

            var setClause = string.Join(",", properties.Select(p => p.Name + " = @" + p.Name));
            var sql = $"UPDATE {_tableName} SET {setClause} WHERE ID = @ID";

            _connection.Execute(sql, entity, transaction: _transaction);
        }

        public void Remove(int id)
        {
            _connection.Execute($"DELETE FROM {_tableName} WHERE ID = @ID",
                new { ID = id },
                transaction: _transaction);
        }
    }
}
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        private IDbTransaction? _transaction;
        private readonly IDbConnection _connection;

        public DapperUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IRepository<Labubu> LabubuRepository =>
            new DapperRepository<Labubu>(_connection, _transaction);

        public IRepository<Collector> CollectorRepository =>
            new DapperRepository<Collector>(_connection, _transaction);

        public ILabubuCollectorRepository LabubuCollectorRepository =>
            new DapperLabubuCollectorRepository(_connection, _transaction);

        public int Commit()
        {
            _transaction!.Commit();
            return 1;
        }

        public void Rollback() => _transaction?.Rollback();

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}

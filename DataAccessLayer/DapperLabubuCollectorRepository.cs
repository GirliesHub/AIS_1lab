using Dapper;
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
    public class DapperLabubuCollectorRepository : ILabubuCollectorRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction? _transaction;

        public DapperLabubuCollectorRepository(IDbConnection connection, IDbTransaction? transaction = null)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public void AssignLabubuToCollector(int labubuId, int collectorId)
        {
            _connection.Execute(@"
                INSERT INTO LabubuCollectors (LabubuId, CollectorId) 
                VALUES (@LabubuId, @CollectorId)",
                new { LabubuId = labubuId, CollectorId = collectorId },
                transaction: _transaction);
        }

        public void RemoveLabubuFromCollector(int labubuId, int collectorId)
        {
            _connection.Execute(@"
                DELETE FROM LabubuCollectors 
                WHERE LabubuId = @LabubuId AND CollectorId = @CollectorId",
                new { LabubuId = labubuId, CollectorId = collectorId },
                transaction: _transaction);
        }

        public List<Labubu> GetLabubusByCollector(int collectorId)
        {
            return _connection.Query<Labubu>(@"
                SELECT l.* FROM Labubus l
                INNER JOIN LabubuCollectors lc ON l.ID = lc.LabubuId
                WHERE lc.CollectorId = @CollectorId",
                new { CollectorId = collectorId },
                transaction: _transaction).ToList();
        }

        public List<Collector> GetCollectorsByLabubu(int labubuId)
        {
            return _connection.Query<Collector>(@"
                SELECT c.* FROM Collectors c
                INNER JOIN LabubuCollectors lc ON c.ID = lc.CollectorId
                WHERE lc.LabubuId = @LabubuId",
                new { LabubuId = labubuId },
                transaction: _transaction).ToList();
        }
    }
}

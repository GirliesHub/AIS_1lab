using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Вероника\\OneDrive\\Рабочий стол\\AIS_LABA_1\\DataAccessLayer\\LibraryDB.mdf\";Integrated Security=True";
           

        private string Table => typeof(T).Name + "s";

        public IEnumerable<T> GetAll()
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.Query<T>($"SELECT * FROM {Table}");
        }

        public T Get(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QuerySingleOrDefault<T>(
                $"SELECT * FROM {Table} WHERE ID=@ID",
                new { ID = id });
        }

        public void Create(T entity)
        {
            using var conn = new SqlConnection(_connectionString);

            var props = typeof(T).GetProperties().Where(p => p.Name != "ID");

            string columns = string.Join(",", props.Select(x => x.Name));
            string values = string.Join(",", props.Select(x => "@" + x.Name));

            string sql = $@"
                INSERT INTO {Table} ({columns})
                VALUES ({values});
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            entity.ID = conn.QuerySingle<int>(sql, entity);
        }

        public void Update(T entity)
        {
            using var conn = new SqlConnection(_connectionString);

            var props = typeof(T).GetProperties().Where(p => p.Name != "ID");
            string setClause = string.Join(",", props.Select(x => $"{x.Name}=@{x.Name}"));

            string sql = $@"
                UPDATE {Table}
                SET {setClause}
                WHERE ID=@ID
            ";

            conn.Execute(sql, entity);
        }

        public void Remove(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Execute($"DELETE FROM {Table} WHERE ID=@ID", new { ID = id });
        }
    }
}
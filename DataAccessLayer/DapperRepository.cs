using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Shared;
using LabubuModel;
using DataAccessLayer;


namespace Model.DataAccessLayer
{
    public class DapperRepository : ILabubuRepository
    {
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\lonit\\source\\repos\\GirliesHub\\AIS_1lab\\DataAccessLayer\\LibraryDB.mdf\";Integrated Security=True";
           

        private string Table => typeof(Labubu).Name + "s";

        public IEnumerable<Labubu> GetAll()
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.Query<Labubu>($"SELECT * FROM {Table}");
        }

        public Labubu Get(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QuerySingleOrDefault<Labubu>(
                $"SELECT * FROM {Table} WHERE ID=@ID",
                new { ID = id });
        }

        public void Create(Labubu entity)
        {
            using var conn = new SqlConnection(_connectionString);

            var props = typeof(Labubu).GetProperties().Where(p => p.Name != "ID");

            string columns = string.Join(",", props.Select(x => x.Name));
            string values = string.Join(",", props.Select(x => "@" + x.Name));

            string sql = $@"
                INSERT INTO {Table} ({columns})
                VALUES ({values});
                SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            entity.ID = conn.QuerySingle<int>(sql, entity);
        }

        public void Update(Labubu entity)
        {
            using var conn = new SqlConnection(_connectionString);

            var props = typeof(Labubu).GetProperties().Where(p => p.Name != "ID");
            string setClause = string.Join(",", props.Select(x => $"{x.Name}=@{x.Name}"));

            string sql = $@"
                UPDATE {Table}
                SET {setClause}
                WHERE ID=@ID
            ";

            conn.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Execute($"DELETE FROM {Table} WHERE ID=@ID", new { ID = id });
        }
    }
}
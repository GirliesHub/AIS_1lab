using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;
using DataAccessLayer;

public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
{
    private readonly string _connectionString;

    public DapperRepository()
    : this(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Вероника\OneDrive\Рабочий стол\AIS_LABA_1\DataAccessLayer\LabubuDB.mdf"";Integrated Security=True")
    {
    }

    /// <summary>
    /// Создаёт репозиторий с указанной строкой подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных.</param>
    public DapperRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Возвращает новый экземпляр подключения к базе данных.
    /// </summary>
    private SqlConnection Connection => new SqlConnection(_connectionString);

    private string Table => typeof(T).Name + "s";

    /// <summary>
    /// Возвращает все записи из таблицы.
    /// </summary>
    public IEnumerable<T> GetAll()
    {
        using var conn = Connection;
        return conn.Query<T>($"SELECT * FROM {Table}");
    }

    /// <summary>
    /// Возвращает сущность по идентификатору.
    /// </summary>
    public T Get(int id)
    {
        using var conn = Connection;
        return conn.QuerySingleOrDefault<T>(
            $"SELECT * FROM {Table} WHERE ID = @ID",
            new { ID = id });
    }

    /// <summary>
    /// Создаёт новую запись в базе данных.
    /// </summary>
    /// <param name="entity">Создаваемая сущность.</param>
    public void Create(T entity)
    {
        using var conn = Connection;

        if (entity is Labubu labubu)
        {
            const string sql = @"
            INSERT INTO Labubus (Name, Color, Rarity, Size, Price)
            VALUES (@Name, @Color, @Rarity, @SizeInternal, @Price);
            SELECT CAST(SCOPE_IDENTITY() AS int);
        ";

            labubu.ID = conn.QuerySingle<int>(sql, labubu);
            return;
        }
    }

    /// <summary>
    /// Обновляет существующую запись в базе данных.
    /// </summary>
    /// <param name="entity">Обновляемая сущность.</param>
    public void Update(T entity)
    {
        using var conn = Connection;

        if (entity is Labubu labubu)
        {
            const string sql = @"
            UPDATE Labubus
            SET Name        = @Name,
                Color       = @Color,
                Rarity      = @Rarity,
                Size        = @SizeInternal,
                Price       = @Price
            WHERE ID = @ID;
        ";

            conn.Execute(sql, labubu);
            return;
        }
    }

    /// <summary>
    /// Удаляет по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой сущности.</param>
    public void Remove(int id)
    {
        using var conn = Connection;
        conn.Execute($"DELETE FROM {Table} WHERE ID = @ID", new { ID = id });
    }
}

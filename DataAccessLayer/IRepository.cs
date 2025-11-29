using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> 
    {
        /// <summary>
        /// Получает все сущности из базы данных.
        /// </summary>
        /// <returns>Коллекция всех сущностей типа T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получает сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность с указанным идентификатором или null, если сущность не найдена.</returns>
        T Get(int id);

        /// <summary>
        /// Создает новую сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность для создания.</param>
        void Create(T entity);

        /// <summary>
        /// Обновляет существующую сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        void Update(T entity);

        /// <summary>
        /// Удаляет сущность из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        void Remove(int id);
    }
}

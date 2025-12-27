using Model;
using SharedLabubu;

namespace BusinessLogic
{
    public interface ILogic
    {
        event Action DataChanged;

        /// <summary>
        /// Добавление новой лабубы
        /// </summary>
        void Create(LabubuDTO dto);

        /// <summary>
        /// Возвращает список всех лабуб
        /// </summary>
        List<LabubuDTO> ReadAll();

        /// <summary>
        /// Получает лабубу по индексу в списке
        /// </summary>
        LabubuDTO Read(int index);

        /// <summary>
        /// Обновляет лабубу по индексу
        /// </summary>
        void Update(int index, LabubuDTO dto);

        /// <summary>
        /// Удаляет лабубу по индексу
        /// </summary>
        void Delete(int index);

        /// <summary>
        /// Группирует лабубы по критерию
        /// </summary>
        Dictionary<string, List<LabubuDTO>> Group(GroupByCriteria criteria);

        /// <summary>
        /// Находит самую дорогую/дешевую лабубу
        /// </summary>
        LabubuDTO FindMostLeastExpensive(bool findMostExpensive);
    }
}

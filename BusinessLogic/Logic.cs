using DataAccessLayer;
using Model;
using SharedLabubu;

namespace BusinessLogic
{
    /// <summary>
    /// Логика приложения для работы с Labubu 
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IRepository<Labubu> _repository;

        /// <summary>
        /// Событие, возникающее после изменения данных (CRUD‑операции).
        /// </summary>
        public event Action DataChanged;

        public Logic(IRepository<Labubu> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Генерирует событие <see cref="DataChanged"/>.
        /// </summary>
        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke();
        }

        /// <summary>
        /// Создаёт новую лабубу по DTO и сохраняет её в репозитории.
        /// </summary>
        /// <param name="dto">DTO с данными новой лабубы.</param>
        public void Create(LabubuDTO dto)
        {
            var entity = LabubuMapper.ToEntity(dto);
            _repository.Create(entity);
            OnDataChanged();
        }

        /// <summary>
        /// Возвращает список всех лабуб в виде DTO.
        /// </summary>
        /// <returns>Список <see cref="LabubuDTO"/>.</returns>
        public List<LabubuDTO> ReadAll()
        {
            return _repository.GetAll()
                             .Select(LabubuMapper.ToDTO)
                             .ToList();
        }

        /// <summary>
        /// Возвращает лабубу по индексу в текущем списке.
        /// </summary>
        /// <param name="index">Индекс элемента в коллекции.</param>
        public LabubuDTO Read(int index)
        {
            var all = ReadAll();
            return index >= 0 && index < all.Count ? all[index] : null;
        }

        /// <summary>
        /// Обновляет данные существующей лабубы по индексу.
        /// </summary>
        /// <param name="index">Индекс редактируемой лабубы.</param>
        /// <param name="dto">Новые данные в виде DTO.</param>
        public void Update(int index, LabubuDTO dto)
        {
            var all = _repository.GetAll().ToList();
            if (index < 0 || index >= all.Count) return;

            var original = all[index];
            var updated = LabubuMapper.ToEntity(dto, original.ID);
            _repository.Update(updated);
            OnDataChanged();
        }

        /// <summary>
        /// Удаляет лабубу по индексу в списке.
        /// </summary>
        /// <param name="index">Индекс удаляемой лабубы.</param>
        public void Delete(int index)
        {
            var all = _repository.GetAll().ToList();
            if (index < 0 || index >= all.Count) return;

            _repository.Remove(all[index].ID);
            OnDataChanged();
        }

        /// <summary>
        /// Группирует лабуб по указанному критерию.
        /// </summary>
        /// <param name="criteria">Критерий группировки (редкость или размер).</param>
        public Dictionary<string, List<LabubuDTO>> Group(GroupByCriteria criteria)
        {
            return criteria switch
            {
                GroupByCriteria.Rarity => _repository.GetAll()
                    .GroupBy(x => x.Rarity.ToString())
                    .ToDictionary(g => g.Key, g => g.Select(LabubuMapper.ToDTO).ToList()),
                GroupByCriteria.Size => _repository.GetAll()
                    .GroupBy(x => x.Size.ToString())
                    .ToDictionary(g => g.Key, g => g.Select(LabubuMapper.ToDTO).ToList()),
                _ => throw new ArgumentException("Неизвестный критерий группировки")
            };
        }

        /// <summary>
        /// Ищет самую дешёвую или самую дорогую лабубу.
        /// </summary>
        /// <param name="findMostExpensive">
        /// true - поиск самой дорогой лабубы, false — самой дешёвой.
        /// </param>
        public LabubuDTO FindMostLeastExpensive(bool findMostExpensive)
        {
            var list = ReadAll();
            if (list.Count == 0) return null;

            return findMostExpensive
                ? list.OrderByDescending(x => x.Price).First()
                : list.OrderBy(x => x.Price).First();
        }
    }
}

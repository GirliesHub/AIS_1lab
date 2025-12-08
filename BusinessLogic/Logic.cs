using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    /// <summary>
    /// Логика приложения для работы с Labubu
    /// </summary>
    public class Logic
    {
        private readonly IRepository<Labubu> _repository;

        /// <summary>
        /// Конструктор с внедрением зависимости (Dependency Injection)
        /// </summary>
        /// <param name="repository">Репозиторий для работы с данными</param>
        public Logic(IRepository<Labubu> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Добавляет новую лабубу
        /// </summary>
        public void AddLabubu(Labubu labubu)
        {
            if (labubu == null)
                throw new ArgumentNullException(nameof(labubu));

            if (labubu.ID <= 0)
            {
                var allLabubus = _repository.GetAll().ToList();
                labubu.ID = allLabubus.Count > 0 ? allLabubus.Max(l => l.ID) + 1 : 1;
            }

            _repository.Create(labubu);
        }

        /// <summary>
        /// Получает все лабубы
        /// </summary>
        public List<Labubu> GetAllLabubus()
        {
            return _repository.GetAll().ToList();
        }

        /// <summary>
        /// Удаляет лабубу по ID
        /// </summary>
        public void RemoveLabubu(int id)
        {
            _repository.Remove(id);
        }

        /// <summary>
        /// Обновляет лабубу
        /// </summary>
        public void UpdateLabubu(Labubu labubu)
        {
            if (labubu == null)
                throw new ArgumentNullException(nameof(labubu));

            var existing = _repository.Get(labubu.ID);
            if (existing == null)
                throw new ArgumentException($"Лабуба с ID {labubu.ID} не найдена");

            _repository.Update(labubu);
        }

        /// <summary>
        /// Группирует лабубы по критерию
        /// </summary>
        public Dictionary<string, List<Labubu>> GroupLabubu(Labubu.GroupByCriteria criteria)
        {
            var all = _repository.GetAll();
            return criteria switch
            {
                Labubu.GroupByCriteria.Rarity =>
                    all.GroupBy(x => x.Rarity.ToString())
                       .ToDictionary(g => g.Key, g => g.ToList()),
                Labubu.GroupByCriteria.Size =>
                    all.GroupBy(x => x.Size.ToString())
                       .ToDictionary(g => g.Key, g => g.ToList()),
                _ => throw new ArgumentException("Unknown criteria")
            };
        }

        /// <summary>
        /// Находит самую дорогую или дешевую лабубу
        /// </summary>
        public Labubu FindMostLeastExpensiveLabubu(bool findMostExpensive)
        {
            var list = _repository.GetAll().ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Список пуст");

            return findMostExpensive
                ? list.OrderByDescending(x => x.Price).First()
                : list.OrderBy(x => x.Price).First();
        }

        /// <summary>
        /// Получает лабубу по ID
        /// </summary>
        public Labubu GetLabubuById(int id)
        {
            return _repository.Get(id);
        }
        /// <summary>
        /// Метод обновления лабубу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="rarity"></param>
        /// <param name="size"></param>
        /// <param name="price"></param>
        public void UpdateLabubu(int id, string name, string color, Labubu.RarityEnum rarity, Labubu.SizeEnum size, decimal price)
        {
            var labubu = new Labubu
            {
                ID = id,
                Name = name,
                Color = color,
                Rarity = rarity,
                Size = size,
                Price = price
            };

            UpdateLabubu(labubu);
        }
    }
}
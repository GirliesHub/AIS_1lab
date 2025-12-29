using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    /// <summary>
    /// Логика приложения для работы с Labubu + UnitOfWork
    /// </summary>
    public class Logic
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Единственный конструктор с UnitOfWork
        /// </summary>
        public Logic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
                var allLabubus = _unitOfWork.LabubuRepository.GetAll().ToList();
                labubu.ID = allLabubus.Count > 0 ? allLabubus.Max(l => l.ID) + 1 : 1;
            }

            _unitOfWork.LabubuRepository.Create(labubu);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Получает все лабубы
        /// </summary>
        public List<Labubu> GetAllLabubus()
        {
            return _unitOfWork.LabubuRepository.GetAll().ToList();
        }

        /// <summary>
        /// Удаляет лабубу по ID
        /// </summary>
        public void RemoveLabubu(int id)
        {
            _unitOfWork.LabubuRepository.Remove(id);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Получает лабубу по ID
        /// </summary>
        public Labubu GetLabubuById(int id)
        {
            return _unitOfWork.LabubuRepository.Get(id);
        }

        /// <summary>
        /// Обновляет лабубу
        /// </summary>
        public void UpdateLabubu(Labubu labubu)
        {
            if (labubu == null)
                throw new ArgumentNullException(nameof(labubu));

            var existing = _unitOfWork.LabubuRepository.Get(labubu.ID);
            if (existing == null)
                throw new ArgumentException($"Лабуба с ID {labubu.ID} не найдена");

            _unitOfWork.LabubuRepository.Update(labubu);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Обновление лабубы по параметрам
        /// </summary>
        public void UpdateLabubu(int id, string name, string color, RarityEnum rarity, SizeEnum size, decimal price)
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

        /// <summary>
        /// Группирует лабубы по критерию
        /// </summary>
        public Dictionary<string, List<Labubu>> GroupLabubu(GroupByCriteria criteria)
        {
            var all = _unitOfWork.LabubuRepository.GetAll().ToList();
            return criteria switch
            {
                GroupByCriteria.Rarity => all.GroupBy(x => x.Rarity.ToString())
                    .ToDictionary(g => g.Key, g => g.ToList()),
                GroupByCriteria.Size => all.GroupBy(x => x.Size.ToString())
                    .ToDictionary(g => g.Key, g => g.ToList()),
                _ => throw new ArgumentException("Неизвестный критерий")
            };
        }

        /// <summary>
        /// Находит самую дорогую или дешевую лабубу
        /// </summary>
        public Labubu FindMostLeastExpensiveLabubu(bool findMostExpensive)
        {
            var list = _unitOfWork.LabubuRepository.GetAll().ToList();
            if (list.Count == 0)
                throw new InvalidOperationException("Список пуст");

            return findMostExpensive
                ? list.OrderByDescending(x => x.Price).First()
                : list.OrderBy(x => x.Price).First();
        }

        /// <summary>
        /// Фильтр по диапазону цен
        /// </summary>
        public List<Labubu> GetLabubusByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0)
                throw new ArgumentException("Цена не может быть отрицательной.");
            if (minPrice > maxPrice)
                throw new ArgumentException("MinPrice не может быть больше MaxPrice.");

            return _unitOfWork.LabubuRepository.GetAll()
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .ToList();
        }

        public List<Collector> GetAllCollectors()
        {
            return _unitOfWork.CollectorRepository.GetAll().ToList();
        }

        public List<Labubu> GetLabubusByCollector(int collectorId)
        {
            return _unitOfWork.LabubuCollectorRepository.GetLabubusByCollector(collectorId);
        }

        public void CreateLabubuWithOwner(Labubu labubu, Collector collector)
        {
            _unitOfWork.CollectorRepository.Create(collector);
            _unitOfWork.LabubuRepository.Create(labubu);
            _unitOfWork.LabubuCollectorRepository.AssignLabubuToCollector(labubu.ID, collector.ID);
            _unitOfWork.Commit();  // 3 таблицы атомарно!
        }

        public void AddCollector(string name, string city)
        {
            var collector = new Collector { Name = name, City = city };
            _unitOfWork.CollectorRepository.Create(collector);
            _unitOfWork.Commit();
        }

        public void AssignLabubuToCollector(int labubuId, int collectorId)
        {
            _unitOfWork.LabubuCollectorRepository.AssignLabubuToCollector(labubuId, collectorId);
            _unitOfWork.Commit();
        }

        //для теста бд было
        public void CreateTestCollectors()
        {
            _unitOfWork.CollectorRepository.Create(new Collector { Name = "Иван", City = "Москва" });
            _unitOfWork.CollectorRepository.Create(new Collector { Name = "Мария", City = "СПб" }); 
            _unitOfWork.Commit();
        }

        public void AddTestLabubu()
        {
         var labubu = new Labubu
         {
             Name = "Pink Monster",
             Color = "Розовый",
             Rarity = RarityEnum.FiveStars,
             Size = SizeEnum.HUGE,
             Price = 999};
             AddLabubu(labubu);
        }
    }

}
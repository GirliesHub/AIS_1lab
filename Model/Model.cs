using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using LabubuModel;
using Model.DataAccessLayer;

namespace Model
{
    public class Model : IModel
    {
        private readonly IRepository<Labubu> _labubuRepository;

        public event EventHandler<LabubuAddEventArgs> EventLabubuAdded = delegate { };
        public event EventHandler<LabubuUpdateEventArgs> EventLabubuUpdated = delegate { };
        public event EventHandler<LabubuSelectEventArgs> EventLabubuDeleted = delegate { };
        public event EventHandler<LabubuLoadListEventArgs> EventLabubuList = delegate { };
        public event EventHandler<LabubuGroupEventArgs> EventLabubuGrouped = delegate { };
        public event EventHandler<LabubuPriceEventArgs> EventLabubuPriceFound = delegate { };

        public Model(IRepository<Labubu> labubuRepository)
        {
            _labubuRepository = labubuRepository;
        }

        // CRUD

        public void AddLabubu(Labubu labubu)
        {
            _labubuRepository.Create(labubu);
            EventLabubuAdded(this, new LabubuAddEventArgs(labubu));
        }

        public void UpdateLabubu(Labubu labubu)
        {
            _labubuRepository.Update(labubu);
            EventLabubuUpdated(this, new LabubuUpdateEventArgs(labubu));
        }

        public void DeleteLabubu(int id)
        {
            _labubuRepository.Delete(id);
            EventLabubuDeleted(this, new LabubuSelectEventArgs(id));
        }

        public void LoadLabubus()
        {
            var list = _labubuRepository.GetAll().ToList();
            EventLabubuList(this, new LabubuLoadListEventArgs(list));
        }

        public void GroupLabubu(GroupByCriteria criteria)
        {
            Dictionary<string, List<Labubu>> grouped;

            switch (criteria)
            {
                case GroupByCriteria.Rarity:
                    grouped = _labubuRepository.GetAll()
                        .GroupBy(l => l.Rarity.ToString())
                        .ToDictionary(g => g.Key, g => g.ToList());
                    break;

                case GroupByCriteria.Size:
                    grouped = _labubuRepository.GetAll()
                        .GroupBy(l => l.Size.ToString())
                        .ToDictionary(g => g.Key, g => g.ToList());
                    break;

                default:
                    grouped = new Dictionary<string, List<Labubu>>();
                    break;
            }

            EventLabubuGrouped(this, new LabubuGroupEventArgs(grouped, criteria));
        }

        public void FindMostLeastExpensiveLabubu(bool findMostExpensive)
        {
            var list = _labubuRepository.GetAll().ToList();

            if (list.Count == 0)
                throw new InvalidOperationException("Список лабуб пуст");

            Labubu labubu = findMostExpensive
                ? list.OrderByDescending(l => l.Price).First()
                : list.OrderBy(l => l.Price).First();

            EventLabubuPriceFound(this,
                new LabubuPriceEventArgs(labubu, findMostExpensive));
        }

    }
}

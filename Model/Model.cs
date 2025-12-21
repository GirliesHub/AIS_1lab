using System;
using System.Collections.Generic;
using System.Linq;
using LabubuModel;
using Model.DataAccessLayer;

namespace Model
{
    public class Model : IModel
    {
        private readonly IRepository<Labubu> _repository;

        public event EventHandler<LabubuAddEventArgs> EventLabubuAdded = delegate { };
        public event EventHandler<LabubuUpdateEventArgs> EventLabubuUpdated = delegate { };
        public event EventHandler<LabubuSelectEventArgs> EventLabubuDeleted = delegate { };
        public event EventHandler<LabubuLoadListEventArgs> EventLabubuList = delegate { };
        public event EventHandler<LabubuGroupEventArgs> EventLabubuGrouped = delegate { };
        public event EventHandler<LabubuPriceEventArgs> EventLabubuPriceFound = delegate { };

        public Model(IRepository<Labubu> repository)
        {
            _repository = repository;
        }

        public void AddLabubu(Labubu labubu)
        {
            _repository.Create(labubu);
            EventLabubuAdded(this, new LabubuAddEventArgs(labubu));
        }

        public void UpdateLabubu(Labubu labubu)
        {
            _repository.Update(labubu);
            EventLabubuUpdated(this, new LabubuUpdateEventArgs(labubu));
        }

        public void DeleteLabubu(int id)
        {
            _repository.Delete(id);
            EventLabubuDeleted(this, new LabubuSelectEventArgs(id));
        }

        public void LoadLabubus()
        {
            var labubus = _repository.GetAll().ToList();
            EventLabubuList(this, new LabubuLoadListEventArgs(labubus));
        }

        public void GroupLabubu(GroupByCriteria criteria)
        {
            var all = _repository.GetAll().ToList();
            Dictionary<string, List<Labubu>> grouped;

            if (criteria == GroupByCriteria.Rarity)
            {
                grouped = all.GroupBy(l => l.Rarity.ToString())
                    .ToDictionary(g => g.Key, g => g.ToList());
            }
            else // Size
            {
                grouped = all.GroupBy(l => l.Size.ToString())
                    .ToDictionary(g => g.Key, g => g.ToList());
            }

            EventLabubuGrouped(this, new LabubuGroupEventArgs(grouped, criteria));
        }

        public void FindMostLeastExpensiveLabubu(bool findMostExpensive)
        {
            var all = _repository.GetAll().ToList();

            if (all.Count == 0)
            {
                EventLabubuPriceFound(this, new LabubuPriceEventArgs(null, findMostExpensive));
                return;
            }

            var labubu = findMostExpensive
                ? all.OrderByDescending(l => l.Price).First()
                : all.OrderBy(l => l.Price).First();

            EventLabubuPriceFound(this, new LabubuPriceEventArgs(labubu, findMostExpensive));
        }
    }
}
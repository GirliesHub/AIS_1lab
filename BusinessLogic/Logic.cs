using DataAccessLayer;
using Model;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic
{
    public class Logic //добавь summary 
    {
        private readonly IRepository<Labubu> repository;

        public Logic()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            string framework = config["DataAccessFramework"] ?? "EF";

            repository = framework == "Dapper"
                ? (IRepository<Labubu>)new DapperRepository<Labubu>()
                : new EntityRepository<Labubu>();
        }

        // CRUD

        public void AddLabubu(int id, string name, string color,
            Labubu.RarityEnum rarity, Labubu.SizeEnum size, decimal price)
        {
            repository.Create(new Labubu
            {
                ID = id,
                Name = name,
                Color = color,
                Rarity = rarity,
                Size = size,
                Price = price
            });
        }

        public List<Labubu> GetAllLabubus()
        {
            return repository.GetAll().ToList();
        }

        public void RemoveLabubu(int id)
        {
            repository.Remove(id);
        }

        public void UpdateLabubu(int id, string name, string color,
            Labubu.RarityEnum rarity, Labubu.SizeEnum size, decimal price)
        {
            repository.Update(new Labubu
            {
                ID = id,
                Name = name,
                Color = color,
                Rarity = rarity,
                Size = size,
                Price = price
            });
        }

        public Dictionary<string, List<Labubu>> GroupLabubu(Labubu.GroupByCriteria criteria)
        {
            var all = repository.GetAll();

            return criteria switch
            {
                Labubu.GroupByCriteria.Rarity =>
                    all.GroupBy(x => x.Rarity.ToString()).ToDictionary(g => g.Key, g => g.ToList()),

                Labubu.GroupByCriteria.Size =>
                    all.GroupBy(x => x.Size.ToString()).ToDictionary(g => g.Key, g => g.ToList()),

                _ => throw new ArgumentException("Unknown criteria")
            };
        }

        public Labubu FindMostLeastExpensiveLabubu(bool findMostExpensive)
        {
            var list = repository.GetAll().ToList();

            if (list.Count == 0)
                throw new InvalidOperationException("Список пуст");

            if (findMostExpensive)
                return list.OrderByDescending(x => x.Price).First();
            else
                return list.OrderBy(x => x.Price).First();
        }

    }
}

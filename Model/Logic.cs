using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class Logic
    {
        private List<Labubu> Labubus = new List<Labubu>();

        public void AddLabubu(int id, string name, string color, string rarity, string size, decimal price)
        {
            if (name == string.Empty || color == string.Empty || rarity == string.Empty || size == string.Empty) { throw new NotImplementedException(); }
            else
            {
                Labubu newLabubu = new Labubu(id, name, color, rarity, size, price);
                Labubus.Add(newLabubu);
            }
        }
        public void RemoveLabubu(int id)
        {
            var labubuToRemove = Labubus.FirstOrDefault(l => l.Id == id);
            if (labubuToRemove != null)
            {
                Labubus.Remove(labubuToRemove);
            }
            else
            {
                throw new ArgumentException($"Лабуба с ID {id} не найдена");
            }
        }

        public List<List<string>> GetAllLabubus()
        {
            List<List<string>> finallist = new List<List<string>>();
            foreach (var labubu in Labubus)
            {
                List<string> labubulist = new List<string>
                {
                    labubu.Id.ToString(),
                    labubu.Name,
                    labubu.Color,
                    labubu.Rarity,
                    labubu.Size,
                    labubu.Price.ToString()
                };
                finallist.Add(labubulist);
            }
            return finallist;
        }

        public void UpdateLabubu(int id, string newName, string newColor, string newRarity, string newSize, decimal newPrice)
        {
            var labubuToUpdate = Labubus.FirstOrDefault(l => l.Id == id);
            if (labubuToUpdate != null)
            {
                if (!string.IsNullOrEmpty(newName))
                {
                    labubuToUpdate.Name = newName;
                }
                if (!string.IsNullOrEmpty(newColor))
                {
                    labubuToUpdate.Color = newColor;
                }
                if (!string.IsNullOrEmpty(newRarity))
                {
                    labubuToUpdate.Rarity = newRarity;
                }
                if (!string.IsNullOrEmpty(newSize))
                {
                    labubuToUpdate.Size = newSize;
                }
                labubuToUpdate.Price = newPrice;
            }
            else
            {
                throw new ArgumentException($"Лабуба с ID {id} не найдена");
            }
        }
        ///<summary>
        ///Бизнес-функция, позволяющая группировать лабуб по редкости или размеру
        ///</summary>
        public Dictionary<string, List<Labubu>> GroupLabubu(Labubu.GroupByCriteria criteria)
        {
            if (Labubus == null || Labubus.Count == 0)
            {
                throw new InvalidOperationException("Список лабуб пуст");
            }
            else
            {
                return criteria switch
                {
                    Labubu.GroupByCriteria.Rarity => Labubus.GroupBy(s => s.Rarity)
                            .ToDictionary(g => g.Key, g => g.ToList()),
                    Labubu.GroupByCriteria.Size => Labubus.GroupBy(c => c.Size)
                            .ToDictionary(g => g.Key, g => g.ToList()),
                    _ => throw new ArgumentException("Неизвестный критерий группировки")
                };
            }
        }
        /// <summary>
        /// Бизнес-функция, позволяющая найти самую дорогую или самую дешевую лабубу в списке
        /// </summary>
        public Labubu FindMostLeastExpensiveLabubu(bool findMostExpensive = true)
        {
            if (Labubus == null || Labubus.Count == 0)
            {
                throw new InvalidOperationException("Список лабуб пуст");
            }
            if (findMostExpensive)
            {
                decimal maxPrice = Labubus.Max(l => l.Price);
                return Labubus.FirstOrDefault(l => l.Price == maxPrice);
            }
            else
            {
                decimal minPrice = Labubus.Min(l => l.Price);
                return Labubus.FirstOrDefault(l => l.Price == minPrice);
            }
        }
    }
}

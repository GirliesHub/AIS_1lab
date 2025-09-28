using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Logic
    {
        private List<Labubu> Labubus = new List<Labubu>();

        public void AddLabubu(int id, string name, string color, int rarity, int size)
        {
            if (name == string.Empty || color == string.Empty) { throw new NotImplementedException(); }
            else
            {
                Labubu newLabubu = new Labubu(id, name, color, rarity, size);
                Labubus.Add(newLabubu);
            }
        }

        public void RemoveLabubu(int number)
        {
            if (Labubus[number] == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                var labubuToRemove = Labubus[number];
                if (labubuToRemove != null)
                {
                    Labubus.Remove(labubuToRemove);
                }
                else
                {
                    throw new NotImplementedException();
                }
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
                    labubu.Rarity.ToString(),
                    labubu.Size.ToString()
                };
                finallist.Add(labubulist);
            }
            return finallist;
        }

        public void UpdateLabubu(int id, string newName, string newColor, int newRarity, int newSize)
        {
            if (id == null) { throw new NotImplementedException(); }
            else
            {
                var labubuToUpdate = Labubus[id];
                if (labubuToUpdate != null)
                {
                    if (newName != string.Empty)
                    {
                        labubuToUpdate.Name = newName;
                    }
                    if (newColor != string.Empty)
                    {
                        labubuToUpdate.Color = newColor;
                    }

                    labubuToUpdate.Rarity = newRarity;
                    labubuToUpdate.Size = newSize;

                    Labubus[id] = labubuToUpdate;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}

using Shared;
using System.Drawing;
using LabubuModel;


namespace Shared
{
    public class ViewLabubuAddEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public RarityEnum Rarity { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }

        public ViewLabubuAddEventArgs(
            string name,
            string color,
            RarityEnum rarity,
            SizeEnum size,
            decimal price)
        {
            Name = name;
            Color = color;
            Rarity = rarity;
            Size = size;
            Price = price;
        }

        //public ViewLabubuAddEventArgs(string name, string color)
        //{
        //    Name = name;
        //    Color = color;
        //}
    }
}

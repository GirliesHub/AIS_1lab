namespace Model
{
    public class Labubu
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Rarity { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }


        public Labubu(int id, string name, string color, string rarity, string size, decimal price)
        {
            Id = id;
            Name = name;
            Color = color;
            Rarity = rarity;
            Size = size;
            Price = price;
        }
        public enum GroupByCriteria
        {
            Rarity,
            Size
        }
    }

}

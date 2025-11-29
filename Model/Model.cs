namespace Model
{
    public class Labubu : IDomainObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public RarityEnum Rarity { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }

        public Labubu() { }
        public Labubu(int id, string name, string color, RarityEnum rarity, SizeEnum size, decimal price)
        {
            ID = id;
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

        public enum RarityEnum
        {
            OneStar = 1,
            TwoStars = 2,
            ThreeStars = 3,
            FourStars = 4,
            FiveStars = 5
        }

        public enum SizeEnum
        {
            Small,
            Medium,
            Big,
            HUGE
        }
    }

}

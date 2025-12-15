using System.ComponentModel.DataAnnotations.Schema;

namespace LabubuModel
{
    public class Labubu : IDomainObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public RarityEnum Rarity { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public SizeEnum Size
        {
            get => (SizeEnum)Enum.Parse(typeof(SizeEnum), SizeInternal);
            set => SizeInternal = value.ToString();
        }

        [Column("Size")]
        public string SizeInternal { get; set; }

        public Labubu()
        {

        }

        public Labubu(int id, string name, string color, RarityEnum rarity, SizeEnum size, decimal price) 
        {
            ID = id;
            Name = name;
            Color = color;
            Rarity = rarity;
            Price = price;
            Size = size;
        }

        public Labubu(string name, string color, RarityEnum rarity, SizeEnum size, decimal price) 
        {
            Name = name;
            Color = color;
            Rarity = rarity;
            Price = price;
            Size = size;
        }
    }
}

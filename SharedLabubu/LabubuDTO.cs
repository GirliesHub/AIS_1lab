using Model;

namespace SharedLabubu
{
    /// <summary>
    /// DTO‑модель лабубы для обмена данными между слоями приложения.
    /// </summary>
    public class LabubuDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public RarityEnum Rarity { get; set; }
        public SizeEnum Size { get; set; } 
        public decimal Price { get; set; }
    }

}

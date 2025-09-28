namespace Model
{
    public class Labubu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Rarity { get; set; }
        public int Size { get; set; }


        public Labubu(int  id, string name, string color, int rarity, int size)
        {
            Id = id;
            Name = name;
            Color = color;
            Rarity = rarity;
            Size = size;
        }
    }

}

using Model;
using SharedLabubu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLabubu
{
    public class LabubuDtoNotify : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _color;
        private RarityEnum _rarity;
        private SizeEnum _size;
        private decimal _price;

        public int ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Color
        {
            get => _color;
            set { _color = value; OnPropertyChanged(); }
        }

        public RarityEnum Rarity
        {
            get => _rarity;
            set { _rarity = value; OnPropertyChanged(); }
        }

        public SizeEnum Size
        {
            get => _size;
            set { _size = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public static LabubuDtoNotify FromDto(LabubuDTO dto)
        {
            if (dto == null) return null;
            return new LabubuDtoNotify
            {
                ID = dto.ID,
                Name = dto.Name,
                Color = dto.Color,
                Rarity = dto.Rarity,
                Size = dto.Size,
                Price = dto.Price
            };
        }

        public LabubuDTO ToDto()
        {
            return new LabubuDTO
            {
                ID = this.ID,
                Name = this.Name,
                Color = this.Color,
                Rarity = this.Rarity,
                Size = this.Size,
                Price = this.Price
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SharedLabubu;

namespace BusinessLogic
{
    /// <summary>
    /// Методы для преобразования Labubu в DTO и обратно
    /// </summary>
    public static class LabubuMapper
    {
        /// <summary>
        /// Преобразует доменную сущность <see cref="Labubu"/> в DTO (labubu -> dto).
        /// для передачи между слоями приложения.
        /// </summary>
        /// <param name="l">Экземпляр сущности Labubu.</param>
        /// <returns>Объект <see cref="LabubuDTO"/> или null, если входной параметр равен null.</returns>
        public static LabubuDTO ToDTO(Labubu l)
        {
            if (l == null) return null;

            return new LabubuDTO
            {
                Name = l.Name,
                Color = l.Color,
                Rarity = l.Rarity,
                Price = l.Price,
                Size = l.Size
            };
        }

        /// <summary>
        /// Преобразует доменную сущность <see cref="Labubu"/> на основе DTO (dto -> labubu).
        /// </summary>
        /// <param name="dto">DTO лабубы.</param>
        /// <param name="id">ID Labubu.</param>
        /// <returns>Объект <see cref="Labubu"/>.</returns>
        public static Labubu ToEntity(LabubuDTO dto, int id = 0)
        {
            return new Labubu
            {
                ID = id,
                Name = dto.Name,
                Color = dto.Color,
                Rarity = dto.Rarity,
                Price = dto.Price,
                Size = dto.Size
            };

        }
    }
}

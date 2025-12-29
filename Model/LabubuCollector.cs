using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LabubuCollector
    {
        [Column("LabubuId")]
        public int LabubuId { get; set; }

        [Column("CollectorId")]
        public int CollectorId { get; set; }

        // Навигационные свойства (для EF)
        public virtual Labubu? Labubu { get; set; }
        public virtual Collector? Collector { get; set; }
    }
}

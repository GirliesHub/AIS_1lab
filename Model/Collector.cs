using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Collector : IDomainObject
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        public List<Labubu> Labubus { get; set; } = new();
    }
}

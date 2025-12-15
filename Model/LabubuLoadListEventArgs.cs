using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;
using System.Collections.Generic;

namespace Model
{
    public class LabubuLoadListEventArgs : EventArgs
    {
        public List<Labubu> Labubus { get; }

        public LabubuLoadListEventArgs(List<Labubu> labubus)
        {
            Labubus = labubus;
        }
    }
}


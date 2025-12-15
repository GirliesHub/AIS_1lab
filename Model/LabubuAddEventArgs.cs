using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;

namespace Model
{
    public class LabubuAddEventArgs : EventArgs
    {
        public Labubu Labubu { get; }

        public LabubuAddEventArgs(Labubu labubu)
        {
            Labubu = labubu;
        }
    }
}


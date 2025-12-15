using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;


namespace Model
{
    public class LabubuUpdateEventArgs : EventArgs
    {
        public Labubu Labubu { get; }

        public LabubuUpdateEventArgs(Labubu labubu)
        {
            Labubu = labubu;
        }
    }
}


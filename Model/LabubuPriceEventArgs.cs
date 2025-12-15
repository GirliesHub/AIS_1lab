using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;


namespace Model
{
    public class LabubuPriceEventArgs : EventArgs
    {
        public Labubu Labubu { get; }
        public bool IsMostExpensive { get; }

        public LabubuPriceEventArgs(Labubu labubu, bool isMostExpensive)
        {
            Labubu = labubu;
            IsMostExpensive = isMostExpensive;
        }
    }
}


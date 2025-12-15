using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;

namespace Shared
{
    public class ViewLabubuPriceEventArgs : EventArgs
    {
        public bool FindMostExpensive { get; }

        public ViewLabubuPriceEventArgs(bool findMostExpensive)
        {
            FindMostExpensive = findMostExpensive;
        }
    }
}

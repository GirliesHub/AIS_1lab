using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class LabubuSelectEventArgs : EventArgs
{
    public int Id { get; }

    public LabubuSelectEventArgs(int id)
    {
        Id = id;
    }
}
}


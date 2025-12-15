using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;

namespace Shared
{
    public class ViewLabubuSelectEventArgs : EventArgs
    {
        public int Id { get; }

        public ViewLabubuSelectEventArgs(int id)
        {
            Id = id;
        }
    }
}

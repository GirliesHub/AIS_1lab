using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabubuModel;

namespace Model
{
    public class LabubuGroupEventArgs : EventArgs
    {
        public Dictionary<string, List<Labubu>> GroupedData { get; }
        public GroupByCriteria Criteria { get; }

        public LabubuGroupEventArgs(
            Dictionary<string, List<Labubu>> groupedData,
            GroupByCriteria criteria)
        {
            GroupedData = groupedData;
            Criteria = criteria;
        }
    }
}


using BusinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLabubu;

namespace ViewModelLabubu
{
    public class VMManager
    {
        private readonly ILogic _logic;

        public LabubuMainViewModel LabubuVM { get; }

        public VMManager(ILogic logic)
        {
            _logic = logic;
            LabubuVM = new LabubuMainViewModel(_logic);
        }

        public EditLabubuViewModel CreateEditLabubuVM(LabubuDtoNotify item, bool isNew)
        {
            return new EditLabubuViewModel(item, isNew);
        }
    }
}

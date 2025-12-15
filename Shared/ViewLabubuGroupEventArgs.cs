using LabubuModel;

namespace Shared
{
    public class ViewLabubuGroupEventArgs : EventArgs
    {
        public GroupByCriteria Criteria { get; }

        public ViewLabubuGroupEventArgs(GroupByCriteria criteria)
        {
            Criteria = criteria;
        }
    }
}

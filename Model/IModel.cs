using LabubuModel;
using Shared;

namespace Model
{
    public interface IModel
    {
        event EventHandler<LabubuAddEventArgs> EventLabubuAdded;
        event EventHandler<LabubuSelectEventArgs> EventLabubuDeleted;
        event EventHandler<LabubuLoadListEventArgs> EventLabubuList;
        event EventHandler<LabubuUpdateEventArgs> EventLabubuUpdated;
        event EventHandler<LabubuGroupEventArgs> EventLabubuGrouped;
        event EventHandler<LabubuPriceEventArgs> EventLabubuPriceFound;

        void AddLabubu(Labubu labubu);
        void DeleteLabubu(int id);
        void LoadLabubus();
        void UpdateLabubu(Labubu labubu);
        void GroupLabubu(GroupByCriteria criteria);
        void FindMostLeastExpensiveLabubu(bool findMostExpensive);
    }
}

using LabubuModel;

namespace Shared
{
    public interface ILabubuView
    {
        event EventHandler<ViewLabubuAddEventArgs> EventViewLabubuAdd;
        event EventHandler<ViewLabubuSelectEventArgs> EventViewLabubuDelete;
        event EventHandler<ViewLabubuLoadListEventArgs> EventViewLabubuLoadList;
        event EventHandler<ViewLabubuUpdateEventArgs> EventViewLabubuUpdate;
        event EventHandler<ViewLabubuGroupEventArgs> EventViewLabubuGroup;
        event EventHandler<ViewLabubuPriceEventArgs> EventViewLabubuPrice;

        void LoadLabubus(List<Labubu> labubus);
        void AddLabubu(Labubu labubu);
        void UpdateLabubu(Labubu labubu);
        void DeleteLabubu(int id);

        void ShowGroupedData(Dictionary<string, List<Labubu>> data, string criteria);
        void ShowLabubuPrice(Labubu labubu, bool isMostExpensive);
        void ShowMessage(string message, string title = "Информация");

        void Run();
    }

}

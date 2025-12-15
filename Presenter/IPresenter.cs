using Model;
using Shared;

namespace Presenter
{
    public interface IPresenter
    {
        void view_LabubuAdd(object sender, ViewLabubuAddEventArgs e);
        void model_LabubuAdd(object sender, LabubuAddEventArgs e);
        void view_LabubuDelete(object sender, ViewLabubuSelectEventArgs e);
        void model_LabubuDelete(object sender, LabubuSelectEventArgs e);
        void view_LabubuLoad(object sender, ViewLabubuLoadListEventArgs e);
        void model_LabubuLoad(object sender, LabubuLoadListEventArgs e);
        void view_LabubuUpdate(object sender, ViewLabubuUpdateEventArgs e);
        void model_LabubuUpdate(object sender, LabubuUpdateEventArgs e);
        void view_LabubuGroup(object sender, ViewLabubuGroupEventArgs e);
        void model_LabubuGroup(object sender, LabubuGroupEventArgs e);
        void view_LabubuPrice(object sender, ViewLabubuPriceEventArgs e);
        void model_LabubuPrice(object sender, LabubuPriceEventArgs e);
    }
}

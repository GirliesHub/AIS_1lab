using Model;
using LabubuModel;
using Shared;

namespace Presenter
{
    public class MainPresenter : IPresenter
    {
        private readonly IModel _model;
        private readonly ILabubuView _view;

        public MainPresenter(ILabubuView view, IModel model)
        {
            _view = view;
            _model = model;

            _view.EventViewLabubuAdd += view_LabubuAdd;
            _view.EventViewLabubuDelete += view_LabubuDelete;
            _view.EventViewLabubuLoadList += view_LabubuLoad;
            _view.EventViewLabubuUpdate += view_LabubuUpdate;
            _view.EventViewLabubuGroup += view_LabubuGroup;
            _view.EventViewLabubuPrice += view_LabubuPrice;

            _model.EventLabubuAdded += model_LabubuAdd;
            _model.EventLabubuDeleted += model_LabubuDelete;
            _model.EventLabubuList += model_LabubuLoad;
            _model.EventLabubuUpdated += model_LabubuUpdate;
            _model.EventLabubuGrouped += model_LabubuGroup;
            _model.EventLabubuPriceFound += model_LabubuPrice;
        }


        public void view_LabubuAdd(object sender, ViewLabubuAddEventArgs e)
        {
            _model.AddLabubu(new Labubu(e.Name, e.Color, e.Rarity, e.Size, e.Price));
        }

        public void view_LabubuDelete(object sender, ViewLabubuSelectEventArgs e)
        {
            _model.DeleteLabubu(e.Id); 
        }

        public void view_LabubuLoad(object sender, ViewLabubuLoadListEventArgs e)
        {
            _model.LoadLabubus();
        }

        public void view_LabubuUpdate(object sender, ViewLabubuUpdateEventArgs e)
        {
            _model.UpdateLabubu(e.Labubu);
        }

        public void view_LabubuGroup(object sender, ViewLabubuGroupEventArgs e)
        {
            _model.GroupLabubu(e.Criteria);
        }

        public void view_LabubuPrice(object sender, ViewLabubuPriceEventArgs e)
        {
            _model.FindMostLeastExpensiveLabubu(e.FindMostExpensive);
        }


        public void model_LabubuAdd(object sender, LabubuAddEventArgs e)
        {
            _view.AddLabubu(e.Labubu);
        }

        public void model_LabubuDelete(object sender, LabubuSelectEventArgs e)
        {
            _view.DeleteLabubu(e.Id);
        }

        public void model_LabubuLoad(object sender, LabubuLoadListEventArgs e)
        {
            _view.LoadLabubus(e.Labubus);
        }

        public void model_LabubuUpdate(object sender, LabubuUpdateEventArgs e)
        {
            _view.UpdateLabubu(e.Labubu);
        }

        public void model_LabubuGroup(object sender, LabubuGroupEventArgs e)
        {
            _view.ShowGroupedData(e.GroupedData, e.Criteria.ToString());
        }

        public void model_LabubuPrice(object sender, LabubuPriceEventArgs e)
        {
            _view.ShowLabubuPrice(e.Labubu, e.IsMostExpensive);
        }
    }
}

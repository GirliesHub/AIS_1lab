using LabubuModel;

namespace Model
{
    public interface ILogicService
    {
        void AddLabubu(Labubu labubu);
        void UpdateLabubu(Labubu labubu);
        void DeleteLabubu(int id);
        List<Labubu> GetAllLabubus();
        Dictionary<string, List<Labubu>> GroupLabubu(GroupByCriteria criteria);
        Labubu FindMostLeastExpensiveLabubu(bool mostExpensive);
    }
}

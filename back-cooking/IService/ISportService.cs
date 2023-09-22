using back_cooking.Models;

namespace back_cooking.IService
{
    public interface ISportService
    {
        List<Sport> GetSports();
        Sport GetSport(string id);
        Sport CreateSport(Sport sport);
        void UpdateSport(string id, Sport sport);
        void RemoveSport(string id);
    }
}

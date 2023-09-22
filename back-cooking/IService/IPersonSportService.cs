using back_cooking.Models;

namespace back_cooking.IService
{
    public interface IPersonSportService
    {
        List<PersonSport> GetPersonSports();
        List<PersonSport> GetByPersonId(string id);
        List<PersonSport> GetBySportId(string id);
        PersonSport CreatePersonSport(PersonSport personSport);  
    }
}

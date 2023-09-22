using back_cooking.Models;

namespace back_cooking.IService
{
    public interface IPersonService
    {
        List<Person> GetPersons();
        Person GetPerson(string id);
        Person CreatePerson(Person person);
        void UpdatePerson(string id, Person person);
        void RemovePerson(string id);
    }
}

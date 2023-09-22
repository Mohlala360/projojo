using back_cooking.data;
using back_cooking.IService;
using back_cooking.Models;
using MongoDB.Driver;

namespace back_cooking.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonService(IDBSettings dBSettings,IMongoClient mongoClient)
        {
           var database =  mongoClient.GetDatabase(dBSettings.DatabaseName);
           _persons = database.GetCollection<Person>("Person");

        }
        Person IPersonService.CreatePerson(Person person)
        {
            _persons.InsertOne(person);
            return person;
        }

        Person IPersonService.GetPerson(string id)
        {
            return _persons.Find(person => person.Id == id).FirstOrDefault();
        }

        List<Person> IPersonService.GetPersons()
        {
           return _persons.Find(person => true).ToList(); 
        }

        void IPersonService.RemovePerson(string id)
        {
            _persons.DeleteOne(person => person.Id == id);
        }

        void IPersonService.UpdatePerson(string id, Person person)
        {
            _persons.ReplaceOne(person => person.Id == id, person);
        }
    }
}

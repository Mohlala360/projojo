using back_cooking.IService;
using back_cooking.Models;
using MongoDB.Driver;
using System;

namespace back_cooking.Services
{
    public class PersonSportService : IPersonSportService
    {
        private readonly IMongoCollection<PersonSport> _personSports;

        public PersonSportService(IDBSettings dBSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(dBSettings.DatabaseName);
            _personSports = database.GetCollection<PersonSport>("PersonSport");

        }

        PersonSport IPersonSportService.CreatePersonSport(PersonSport personSport)
        {
            _personSports.InsertOne(personSport);
            return personSport;
        }
        List<PersonSport> IPersonSportService.GetByPersonId(string id)
        {
            return _personSports.Find(personSport => personSport.PersonId == id).ToList();
        }


        List<PersonSport> IPersonSportService.GetBySportId(string id)
        {
            return _personSports.Find(personSport => personSport.SportId == id).ToList();
        }


        List<PersonSport> IPersonSportService.GetPersonSports()
        {
            return _personSports.Find(d => true).ToList();
        }
    }
}

using back_cooking.IService;
using back_cooking.Models;
using MongoDB.Driver;

namespace back_cooking.Services
{
    public class SportService : ISportService
    {
        private readonly IMongoCollection<Sport> _Sports;

        public SportService(IDBSettings dBSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(dBSettings.DatabaseName);
            _Sports = database.GetCollection<Sport>("Sport");

        }
        Sport ISportService.CreateSport(Sport Sport)
        {
            _Sports.InsertOne(Sport);
            return Sport;
        }

        Sport ISportService.GetSport(string id)
        {
            return _Sports.Find(Sport => Sport.Id == id).FirstOrDefault();
        }

        List<Sport> ISportService.GetSports()
        {
            return _Sports.Find(sport => true).ToList();
        }

        void ISportService.RemoveSport(string id)
        {
            _Sports.DeleteOne(sport => sport.Id == id);
        }

        void ISportService.UpdateSport(string id, Sport sport)
        {
            _Sports.ReplaceOne(sport => sport.Id == id, sport);
        }

    }
}

using back_cooking.IService;
using back_cooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_cooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonSportController : ControllerBase
    {

        private readonly IPersonSportService _personSportService;
        public PersonSportController(IPersonSportService personSportService)
        {
            this._personSportService = personSportService;
        }

        [HttpGet]
        public ActionResult<List<PersonSport>> GetPersons()
        {
            return _personSportService.GetPersonSports();
        }

        [HttpGet("person/{personId}")]
        public ActionResult<List<PersonSport>> GetByPersonId(string personId)
        {
            var personSport = _personSportService.GetByPersonId(personId);

            if (personSport == null)
            {
                return NotFound($"Person with Id {personId} has no sport ");
            }

            return personSport;
        }

        [HttpGet("sport/{sportId}")]
        public ActionResult<List<PersonSport>> GetBySportId(string sportId)
        {
            var personSport = _personSportService.GetByPersonId(sportId);

            if (personSport == null)
            {
                return NotFound($"Sport with Id {sportId} has no count ");
            }

            return personSport;
        }

        [HttpPost]
        public ActionResult<PersonSport> CreatePerson([FromBody] PersonSport personSport)
        {
           return _personSportService.CreatePersonSport(personSport);
              
        }

       

        
    }
}

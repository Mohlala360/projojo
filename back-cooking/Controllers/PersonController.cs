using back_cooking.IService;
using back_cooking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_cooking.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IPersonSportService _personSportService;
        public PersonController(IPersonService personService, IPersonSportService personSportService)
        {
            this._personService = personService;
            this._personSportService = personSportService;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            return _personService.GetPersons();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(string id)
        {
           var person = _personService.GetPerson(id);

            if(person == null)
            {
                return NotFound($"Person with Id {id} can not be found");
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson([FromBody] Person person)
        {
            _personService.CreatePerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePerson(string id,[FromBody] Person person)
        {
            var existingPerson = _personService.GetPerson(id);

            if (existingPerson == null)
            {
                return NotFound($"Person with Id {id} can not be found");
            }
            _personService.UpdatePerson(id,person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult RemovePerson(string id)
        {
            var person = _personService.GetPerson(id);

            if (person == null)
            {
                return NotFound($"Person with Id {id} can not be found");
            }
            _personService.RemovePerson(id);
            return Ok($"Person with Id {id} deleted");
        }

        [HttpGet("personsport/{id}")]
        public ActionResult<List<PersonSport>> GetPersonSport(string id)
        {
            var personSport = _personSportService.GetByPersonId(id);

            if (personSport == null)
            {
                return NotFound($"Person with Id {id} has no sport found");
            }

            return personSport;
        }
    }
}

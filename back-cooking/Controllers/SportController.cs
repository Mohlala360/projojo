using back_cooking.IService;
using back_cooking.Models;
using back_cooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_cooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly ISportService _SportService;
        private readonly IPersonSportService _personSportService;
        public SportController(ISportService SportService, IPersonSportService personSportService)
        {
            this._SportService = SportService;
            this._personSportService = personSportService;
        }

        [HttpGet]
        public ActionResult<List<Sport>> GetSports()
        {
            return _SportService.GetSports();
        }

        [HttpGet("{id}")]
        public ActionResult<Sport> GetSport(string id)
        {
            var Sport = _SportService.GetSport(id);

            if (Sport == null)
            {
                return NotFound($"Sport with Id {id} can not be found");
            }

            return Sport;
        }

        [HttpPost]
        public ActionResult<Sport> CreateSport([FromBody] Sport sport)
        {
            _SportService.CreateSport(sport);
            return CreatedAtAction(nameof(GetSport), new { id = sport.Id }, sport);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSport(string id, [FromBody] Sport sport)
        {
            var existingSport = _SportService.GetSport(id);

            if (existingSport == null)
            {
                return NotFound($"Sport with Id {id} can not be found");
            }
            _SportService.UpdateSport(id, sport);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveSport(string id)
        {
            var sport = _SportService.GetSport(id);

            if (sport == null)
            {
                return NotFound($"Sport with Id {id} can not be found");
            }
            _SportService.RemoveSport(id);
            return Ok($"Sport with Id {id} deleted");
        }

        [HttpGet("count/{id}")]
        public ActionResult<int> GetSportCount(string id)
        {
            var Sport = _personSportService.GetBySportId(id);

            if (Sport == null)
            {
                return NotFound($"Sport with Id {id} can not be found");
            }

            return Sport.Count;
        }
    }
}

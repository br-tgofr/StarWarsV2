using Microsoft.AspNetCore.Mvc;
using StarWars.Domain.Interface;

namespace StarWars.Api.Services
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdPeopleAsync([FromRoute] int id)
        {
            var people = await peopleService.GetPeople(id);

            if (people is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(people);
            }
        }

        private IActionResult CreatedAtAction(object value, int id)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace StarWars.Api.Services
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdPeopleAsync([FromRoute] int id)
        {
            var people = await new PeopleService().GetPeople(id);

            if (people is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(people);
            }
        } 
    }
}

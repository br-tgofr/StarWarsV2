using Microsoft.AspNetCore.Mvc;
using StarWars.Domain.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StarWars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService filmsService;
        public FilmsController(IFilmsService filmsService)
        {
            this.filmsService = filmsService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdFilmAsync([FromRoute] int id)
        {
            var films = await filmsService.GetFilm(id);

            if (films is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(films);
            }
        }
    }
}

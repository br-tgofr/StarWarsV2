using StarWars.Api.Models;
using StarWars.Domain.Interface;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Services
{
    public class FilmsService : IFilmsService
    {
        private readonly IFilmsRepository filmsRepository;
        private readonly IFilmsAcl filmsAcl;

        public FilmsService(IFilmsRepository filmsRepository, IFilmsAcl filmsAcl)
        {
            this.filmsRepository = filmsRepository;
            this.filmsAcl = filmsAcl;
        }
        public async Task<Films> GetFilm(int id)
        {
            var filmsEntitie = await filmsRepository.FindFilmsById(id);

            if (filmsEntitie is not null)
            {
                return Films.Map(filmsEntitie);
            }
            else
            {
                var result = await filmsAcl.GetFilmsAcl(id);

                if (result is not null)
                {
                    await filmsRepository.SaveFilms(result);
                    return Films.Map(result);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

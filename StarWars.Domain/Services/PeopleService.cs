using StarWars.Api.Models;
using StarWars.Domain.Entities;
using StarWars.Domain.Interface;
using StarWars.Domain.Models;
using StarWars.Domain.Services;
using System.Collections.Generic;

namespace StarWars.Api.Services
{
    public class PeopleService : IPeopleService

    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IPeopleAcl peopleAcl;
        private readonly IFilmsRepository filmsRepository;
        private readonly IPeopleFilmsRepository peopleFilmsRepository;
        private readonly IFilmsService filmsService;

        public PeopleService(IPeopleRepository peopleRepository, IPeopleAcl peopleAcl, IFilmsRepository filmsRepository, IPeopleFilmsRepository peopleFilmsRepository, IFilmsService filmsService)
        {
            this.peopleRepository = peopleRepository;
            this.peopleAcl = peopleAcl;
            this.filmsRepository = filmsRepository;
            this.peopleFilmsRepository = peopleFilmsRepository;
            this.filmsService = filmsService;
        }
        public async Task<People> GetPeople(int id)
        {
            var peopleEntitie = await peopleRepository.FindPeopleById(id);

            if (peopleEntitie is not null)
            {
                return People.Map(peopleEntitie);
            }
            else
            {
                var result = await peopleAcl.GetPeopleAcl(id);

                if (result is not null)
                {
                    await peopleRepository.SavePeople(result);

                    foreach (var films in result.Films)
                    {
                        string x = films.Substring(28, (films.Length - 1) - 28);
                        int idFilms = Int32.Parse(x);

                        await filmsService.GetFilm(idFilms);

                        PeopleFilmsEntity peopleFilmsEntity = await peopleFilmsRepository.FindPeopleFilms(result.Id, idFilms);

                        if (peopleFilmsEntity is null)
                        {
                            await peopleFilmsRepository.SavePeopleFilms(result.Id, idFilms);
                        }
                    }

                    return People.Map(result);
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<People> GetPeopleFilms(int id)
        {
            var peopleEntitie = await peopleRepository.FindPeopleFilmsById(id);

            if (peopleEntitie is not null)
            {
                return People.Map(peopleEntitie);
            }
            else
            {
              return null;
            }
        }
    }
}

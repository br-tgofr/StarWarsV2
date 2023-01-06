using StarWars.Api.Models;
using StarWars.Domain.Interface;

namespace StarWars.Api.Services
{
    public class PeopleService : IPeopleService

    {
        private readonly IPeopleRepository peopleRepository;
        private readonly IPeopleAcl peopleAcl;
        public PeopleService(IPeopleRepository peopleRepository, IPeopleAcl peopleAcl)
        {
            this.peopleRepository = peopleRepository;
            this.peopleAcl = peopleAcl;
        }
        public async Task<People> GetPeople(int id)
        {
            var peopleEntitie = await peopleRepository.FindPeopleById(id);

            if (peopleEntitie != null)
            {
                return People.Map(peopleEntitie);
            }
            else
            {
                var result = await peopleAcl.GetPeopleAcl(id);

                if (result is not null)
                {
                    await peopleRepository.SavePeople(result, id);
                    return People.Map(result);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

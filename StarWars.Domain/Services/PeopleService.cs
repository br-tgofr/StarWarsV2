using StarWars.Api.Models;
using StarWars.Infra.Acl;
using StarWars.Infra.Data;

namespace StarWars.Api.Services
{
    public class PeopleService
    {
        public async Task<People> GetPeople(int id)
        {
            var peopleRepo = new PeopleRepository();
            var peopleEntitie = await peopleRepo.FindPeopleById(id);

            if (peopleEntitie != null)
            {
                return People.Map(peopleEntitie);
            }
            else
            {
                var peopleAcl = await new PeopleAcl().GetPeopleAcl(id);

                if (peopleAcl is not null)
                {
                    peopleAcl.Id = id;
                    await peopleRepo.SavePeople(peopleAcl);
                    return People.Map(peopleAcl);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

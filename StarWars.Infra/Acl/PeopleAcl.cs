using Newtonsoft.Json;
using StarWars.Api.Models;
using StarWars.Domain.Interface;

namespace StarWars.Infra.Acl
{
    public class PeopleAcl : IPeopleAcl
    {
        public async Task<PeopleEntity> GetPeopleAcl(int id)
        {
            using (var httpCliente = new HttpClient())
            {
                httpCliente.BaseAddress = new Uri("https://swapi.dev/api/");
                var response = await httpCliente.GetAsync($"people/{id}/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var getPeople = JsonConvert.DeserializeObject<PeopleEntity>(jsonResponse);

                if (getPeople.Id == 0)
                {
                    getPeople.Id = id;
                }

                return getPeople;
            }
        }
    }
}

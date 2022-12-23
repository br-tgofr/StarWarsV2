using Newtonsoft.Json;
using StarWars.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Acl
{
    public class PeopleAcl
    {
        public async Task<PeopleEntity> GetPeopleAcl(int id)
        {
            using (var httpCliente = new HttpClient())
            {
                httpCliente.BaseAddress = new Uri("https://swapi.dev/api/");
                var response = await httpCliente.GetAsync($"people/{id}/");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var getPeople = JsonConvert.DeserializeObject<PeopleEntity>(jsonResponse);

                return getPeople;
            }
        }
    }
}

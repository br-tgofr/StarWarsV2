using Newtonsoft.Json;
using StarWars.Domain.Entities;
using StarWars.Domain.Interface;
using System.Net.Http;

namespace StarWars.Infra.Acl
{
    public class FilmsAcl : IFilmsAcl
    {
        public async Task<FilmsEntity> GetFilmsAcl(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
                var response = await httpClient.GetAsync($"films/{id}");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var getFilms = JsonConvert.DeserializeObject<FilmsEntity>(jsonResponse);

                if (getFilms.Id is 0)
                {
                    getFilms.Id = id;
                }

                return getFilms;
            }
        }
    }
}

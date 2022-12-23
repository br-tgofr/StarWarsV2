using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.Models
{
    public class People
    {
        [Key]
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        internal static People Map(PeopleEntity peopleEntitie)
        {
            People people    = new People();
            people.Id        = peopleEntitie.Id;
            people.Name      = peopleEntitie.Name;
            people.Height    = peopleEntitie.Height;
            people.Mass      = peopleEntitie.Mass;
            people.HairColor = peopleEntitie.HairColor;
            people.SkinColor = peopleEntitie.SkinColor;
            people.EyeColor  = peopleEntitie.EyeColor;
            people.BirthYear = peopleEntitie.BirthYear;
            people.Gender    = peopleEntitie.Gender;
            people.Homeworld = peopleEntitie.Homeworld;
            people.Films     = peopleEntitie.Films;
            people.Species   = peopleEntitie.Species;
            people.Vehicles  = peopleEntitie.Vehicles;
            people.Starships = peopleEntitie.Starships;
            people.Created   = peopleEntitie.Created;
            people.Edited    = peopleEntitie.Edited;
            people.Url       = peopleEntitie.Url;

            return people;
        }
    }
}

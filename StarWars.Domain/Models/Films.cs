using Newtonsoft.Json;
using StarWars.Api.Models;
using StarWars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Models
{
    public class Films
    {
        [Key]
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public int Episode_id { get; set; }

        [JsonProperty("opening_crawl")]
        public string Opening_crawl { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public string Release_date { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        internal static Films Map(FilmsEntity filmsEntitie)
        {
            Films films = new Films();
            films.Id = filmsEntitie.Id;
            films.Title = filmsEntitie.Title;
            films.Episode_id = filmsEntitie.Episode_id;
            films.Opening_crawl = filmsEntitie.Opening_crawl;
            films.Director = filmsEntitie.Director;
            films.Producer = filmsEntitie.Producer;
            films.Release_date = filmsEntitie.Release_date;
            films.Created = filmsEntitie.Created;
            films.Edited = filmsEntitie.Edited;
            films.Url = filmsEntitie.Url;

            return films;
        }
    }
}

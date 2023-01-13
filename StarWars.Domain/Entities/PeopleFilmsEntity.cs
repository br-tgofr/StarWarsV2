using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.Models
{
    public class PeopleFilmsEntity
    {
        [Key]
        [Required]
        public int IdPeople { get; set; }

        [Key]
        [Required]
        public int IdFilms { get; set; }
    }
}
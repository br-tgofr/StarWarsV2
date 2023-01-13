using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models
{
    public class PeopleFilms
    {
        [Key]
        [Required]
        public int IdPeople { get; set; }
       
        [Key]
        [Required]
        public int IdFilms { get; set; }
    }
}

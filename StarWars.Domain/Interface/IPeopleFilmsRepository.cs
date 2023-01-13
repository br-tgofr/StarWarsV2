using StarWars.Api.Models;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IPeopleFilmsRepository
    {
        public Task<PeopleFilmsEntity> FindPeopleFilms(int IdPeople, int IdFilms);
        public Task<PeopleFilmsEntity> SavePeopleFilms(int IdPeople, int IdFilms);
    }
}

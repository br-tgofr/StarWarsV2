using StarWars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IPeopleRepository
    {
        public Task<PeopleEntity> FindPeopleById(int id);
        public Task<PeopleEntity> SavePeople(PeopleEntity peopleResult, int id);
    }
}

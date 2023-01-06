using StarWars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IPeopleAcl
    {
        public Task<PeopleEntity> GetPeopleAcl(int id);
    }
}

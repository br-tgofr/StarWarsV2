using StarWars.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IPeopleService
    {
        public Task<People> GetPeople(int id);
    }
}

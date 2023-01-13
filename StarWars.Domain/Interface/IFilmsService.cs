using StarWars.Api.Models;
using StarWars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IFilmsService
    {
        public Task<Films> GetFilm(int id);
    }
}

using StarWars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IFilmsRepository
    {
        public Task<FilmsEntity> FindFilmsById(int id);
        public Task<FilmsEntity> SaveFilms(FilmsEntity filmsResult);
    }
}

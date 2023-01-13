using StarWars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Interface
{
    public interface IFilmsAcl
    {
        public Task<FilmsEntity> GetFilmsAcl(int id);
    }
}

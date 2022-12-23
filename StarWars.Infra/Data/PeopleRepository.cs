using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Builder;
using StarWars.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StarWars.Infra.Data.IDbConnection;

namespace StarWars.Infra.Data
{
    public class PeopleRepository
    {
        private WebApplication app;
        public async Task<PeopleEntity> FindPeopleById(int id)
        {
            app.MapGet($"{id}", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                return con.GetAll<PeopleEntity>().ToList();
            });

            return null;
        }

        public async Task SavePeople(PeopleEntity peopleAcl)
        {

        }
    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using StarWars.Api.Models;
using StarWars.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Data
{
    public class PeopleFilmsRepository : IPeopleFilmsRepository
    {
        private readonly IConfiguration configuration;
        public PeopleFilmsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<PeopleFilmsEntity> FindPeopleFilms(int IdPeople, int IdFilms)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var getPeopleFilmsResult = await connection.QueryAsync<PeopleFilmsEntity>(PeopleFilmsSqlStatement.GetPeopleFilmsKey(), new { IdPeople, IdFilms });

                if (getPeopleFilmsResult is not null)
                {
                    return getPeopleFilmsResult.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<PeopleFilmsEntity> SavePeopleFilms(int IdPeople, int IdFilms)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var result = await connection.ExecuteScalarAsync(PeopleFilmsSqlStatement.InsertPeopleFilmsKey(), new
                {
                    IdPeople,
                    IdFilms
                });
            }
            return null;
        }
    }
}

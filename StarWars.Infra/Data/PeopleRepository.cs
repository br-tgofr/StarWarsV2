using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using StarWars.Api.Models;
using StarWars.Domain.Interface;
using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace StarWars.Infra.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IConfiguration configuration;
        public PeopleRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<PeopleEntity> FindPeopleById(int id)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var getPeopleresult = await connection.QueryAsync<PeopleEntity>(PeopleSlqStatement.GetPeopleIdQueryBase(), new { id });
                
                if (getPeopleresult is not null)
                {
                    return getPeopleresult.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<PeopleEntity> SavePeople(PeopleEntity peopleResult, int id)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var result = await connection.ExecuteScalarAsync(PeopleSlqStatement.InsertPeopleQueryBase(), new
                {
                    peopleResult.Id,
                    peopleResult.Name,
                    peopleResult.Height,
                    peopleResult.Mass,
                    peopleResult.HairColor,
                    peopleResult.SkinColor,
                    peopleResult.EyeColor,
                    peopleResult.BirthYear,
                    peopleResult.Gender,
                    peopleResult.Homeworld,
                    peopleResult.Films,
                    //peopleResult.Species,
                    //peopleResult.Vehicles,
                    // peopleResult.Starships,
                    peopleResult.Created,
                    peopleResult.Edited,
                    peopleResult.Url
                });
                
                var bulkInsert = new List<Object>();

                foreach (var films in peopleResult.Films)
                {
                    bulkInsert.Add(films);
                }
            }
            return null;   
        }
    }
}
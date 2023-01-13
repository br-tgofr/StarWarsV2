using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using StarWars.Domain.Entities;
using StarWars.Domain.Interface;

namespace StarWars.Infra.Data
{
    public class FilmsRepository : IFilmsRepository
    {
        private readonly IConfiguration configuration;
        public FilmsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<FilmsEntity> FindFilmsById(int id)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var getFilmsResult = await connection.QueryAsync<FilmsEntity>(FilmsSqlStatement.GetFilmsIdQueryBase(), new { id });

                if (getFilmsResult is not null)
                {
                    return getFilmsResult.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<FilmsEntity> SaveFilms(FilmsEntity filmsResult)
        {
            using (var connection = new SqlConnection(configuration.GetSection("StarWarsApiConnection").Value.ToString()))
            {
                var result = await connection.ExecuteScalarAsync(FilmsSqlStatement.InsertFilmsQueryBase(), new
                {
                    filmsResult.Id,
                    filmsResult.Title,
                    filmsResult.Episode_id,
                    filmsResult.Opening_crawl,
                    filmsResult.Director,
                    filmsResult.Producer,
                    filmsResult.Release_date,
                    filmsResult.Created,
                    filmsResult.Edited,
                    filmsResult.Url
                });
            }
            return null;
        }
    }
}

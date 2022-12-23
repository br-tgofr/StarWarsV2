using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StarWars.Infra.Data.IDbConnection;

namespace StarWars.Infra.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<GetConnection>(sp =>
             async () =>
             {
                 string connectionString = sp.GetService<IConfiguration>().GetConnectionString("StarWarsApiConnection");
                 var connection = new SqlConnection(connectionString);
                 await connection.OpenAsync();
                 return connection;
             });

            return builder;
        }
    }
}

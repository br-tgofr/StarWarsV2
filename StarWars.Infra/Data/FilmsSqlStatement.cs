using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public static class FilmsSqlStatement
    {
        public static string GetFilmsIdQueryBase() => @"SELECT [Id]
          ,[Title]
          ,[Episode_id]
          ,[Opening_crawl]
          ,[Director]
          ,[Producer]
          ,[Release_date]
          ,[Created]
          ,[Edited]
          ,[Url]
        FROM [dbo].[FILMS] WHERE Id = @id";

        public static string InsertFilmsQueryBase() => @"INSERT INTO [dbo].[FILMS]
          ([Id]
          ,[Title]
          ,[Episode_id]
          ,[Opening_crawl]
          ,[Director]
          ,[Producer]
          ,[Release_date]
          ,[Created]
          ,[Edited]
          ,[Url])
         VALUES
           (
           @Id
          ,@Title
          ,@Episode_id
          ,@Opening_crawl
          ,@Director
          ,@Producer
          ,@Release_date
          ,@Created
          ,@Edited
          ,@Url)";
    }
}

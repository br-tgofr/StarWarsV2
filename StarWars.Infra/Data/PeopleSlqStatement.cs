using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public static class PeopleSlqStatement
    {
        public static string GetPeopleIdQueryBase()  => @"SELECT [Id]
            ,[Name]
            ,[Height]
            ,[Mass]
            ,[HairColor]
            ,[SkinColor]
            ,[EyeColor]
            ,[BirthYear]
            ,[Gender]
            ,[Homeworld]
            ,[Created]
            ,[Edited]
            ,[Url] 
    FROM [dbo].[PEOPLE] 
    WHERE 
    Id = @id";
        public static string InsertPeopleQueryBase() => @"INSERT INTO [dbo].[PEOPLE]
           ([Id]
           ,[Name]
           ,[Height]
           ,[Mass]
           ,[HairColor]
           ,[SkinColor]
           ,[EyeColor]
           ,[BirthYear]
           ,[Gender]
           ,[Homeworld]
           ,[Created]
           ,[Edited]
           ,[Url])
     VALUES
           (@Id, @Name, @Height, @Mass, @HairColor, @SkinColor, @EyeColor, @BirthYear, @Gender, @Homeworld, @Created, @Edited, @Url)";

        public static string GetPeopleFilmsQueryBase() => @"SELECT p.Id
            ,[Name]
            ,[Height]
            ,[Mass]
            ,[HairColor]
            ,[SkinColor]
            ,[EyeColor]
            ,[BirthYear]
            ,[Gender]
            ,[Homeworld]
            ,p.Created
            ,p.Edited
            ,p.Url
			,f.Url
    FROM [dbo].[PEOPLE] p
	LEFT JOIN PEOPLE_FILMS pf ON p.Id = pf.IdPeople
	LEFT JOIN FILMS f ON f.Id = pf.IdFilms
    WHERE 
    p.Id = @id";

    }
}
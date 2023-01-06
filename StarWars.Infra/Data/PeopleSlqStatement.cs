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
        public static string GetPeopleIdQueryBase()  => @"SELECT [Id], [Name], [Height], [Mass], [HairColor], [SkinColor], [EyeColor], [BirthYear], [Gender], [Homeworld], [Films], [Created], [Edited], [Url] FROM [dbo].[PEOPLE] WHERE Id = @id";
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
           ,[Films]
           ,[Created]
           ,[Edited]
           ,[Url])
     VALUES
           (@Id, @Name, @Height, @Mass, @HairColor, @SkinColor, @EyeColor, @BirthYear, @Gender, @Homeworld, @Films, @Created, @Edited, @Url)";
    }
}
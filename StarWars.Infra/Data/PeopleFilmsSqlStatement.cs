using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Data
{
    public class PeopleFilmsSqlStatement
    {
        public static string GetPeopleFilmsKey() => @"SELECT IdPeople, IdFilms From PEOPLE_FILMS WHERE IdPeople = @IdPeople AND IdFilms = @IdFilms";

        public static string InsertPeopleFilmsKey() => @"INSERT INTO PEOPLE_FILMS (IdPeople, IdFilms) Values (@IdPeople, @IdFilms)";
    }
}

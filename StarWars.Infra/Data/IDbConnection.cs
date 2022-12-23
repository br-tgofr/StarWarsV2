using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Infra.Data
{
    public class IDbConnection
    {
        public delegate Task<System.Data.IDbConnection> GetConnection();
    }
}

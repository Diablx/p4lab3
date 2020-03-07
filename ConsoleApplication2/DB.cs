using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class DB
    {
        public void Select(IDbConnection conn)
        {
            var sql = "SELECT * FROM Northwind.dbo.Region";
            var result = conn.Query<Region>(sql);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.RegionID.ToString()}: {item.RegionDescription}");
            }
            
        }

        public void Insert(IDbConnection connection)
        {
            var sql = $"INSERT INTO ?() VALUES()";
            var result = connection.Query<Region>(sql);
        }

        public void Update(IDbConnection connection)
        {
            var sql = $"UPDATE ? SET ? = ? WHERE ? = ?";
            var result = connection.Query<Region>(sql);

        }

        public void Delete(IDbConnection connection)
        {
            var sql = $"DELETE ? FROM ? WHERE ? = ?";
            var result = connection.Query<Region>(sql);

        }


    }
}

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
        public List<Region> Select(IDbConnection conn)
        {

            List<Region> regions = new List<Region>();
            var sql = "SELECT * FROM Northwind.dbo.Region";
            var result = conn.Query<Region>(sql);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.RegionID.ToString()}: {item.RegionDescription}");
                regions.Add(item);
            }
            return regions;
        }

        public void Insert(IDbConnection connection, int id, string description)
        {
            var sql = $"INSERT INTO Northwind.dbo.Region(RegionID, RegionDescription) VALUES(@id, @desc)";

            var changed = connection.Execute(sql,
                new
                {
                    id = id,
                    desc = description
                });
            Console.WriteLine($"Wrzucono {changed} do bazy ... .");
        }

        public void Update(IDbConnection connection)
        {
            var sql = $"UPDATE ? SET ? = ? WHERE ? = ?";
            var result = connection.Query<Region>(sql);

        }

        public void Delete(IDbConnection connection, List<Region> regions)
        {
            foreach (var item in regions)
            {
                var sql = $"DELETE FROM Northwind.dbo.Region WHERE {item.RegionID} = 301";
                var result = connection.Execute(sql);
                if (item.RegionID == 300)
                {
                    Console.WriteLine($"Usunięto region {item.RegionDescription}");
                }
            }
        }
    }
}

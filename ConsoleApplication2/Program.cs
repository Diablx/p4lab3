using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            using(var connection = new SqlConnection())
            {
                var db = new DB();

                //db.Insert(connection, 301, "Wuhan");
                db.Delete(connection, db.Select(connection));
                connection.Close();
            }
            
        }
    }
}

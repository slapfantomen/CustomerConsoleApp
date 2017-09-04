using System;
using System.Data.SqlClient;

namespace CustomerConsoleApp
{
    class DbHandler
    {
        public static void QueryDb(string sql)
        {
            var connstr = "Server = (localdb)\\mssqllocaldb; Database = Customers";

            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql, con))
                {
                    con.Open();
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[1]);
                    }
                }
            }
        }
    }
}

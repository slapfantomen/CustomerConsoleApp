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
                        int count = reader.FieldCount;
                        for (int i = 1; i < count; i++)
                        {
                            Console.Write(reader.GetValue(i) + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

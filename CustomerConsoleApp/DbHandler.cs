using System;
using System.Data.SqlClient;

namespace CustomerConsoleApp
{
    class DbHandler
    {
        static string connstr = "Server = (localdb)\\mssqllocaldb; Database = Customers";

        public static void QueryDb(string sql)
        {
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
        //public void AddCustomerToDb(Customer customer)
        //{
        //    using (var con = new SqlConnection(connstr))
        //    {
        //        using (var com = new SqlCommand(sql, con))
        //        {
        //            con.Open();
        //            var reader = com.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                int count = reader.FieldCount;
        //                for (int i = 1; i < count; i++)
        //                {
        //                    Console.Write(reader.GetValue(i) + " ");
        //                }
        //                Console.WriteLine();
        //            }
        //        }
        //    }
        //}
    }
}

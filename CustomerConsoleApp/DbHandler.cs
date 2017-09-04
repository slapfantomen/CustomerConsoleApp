using System;
using System.Data.SqlClient;

namespace CustomerConsoleApp
{
    static class DbHandler
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
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write(reader.GetValue(i) + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void AddCustomerToDb(Customer customer)
        {
            var sql = $"insert into Customers (first_name, last_name, email_address, phonenumber)" +
                $"values('{customer.FirstName}', '{customer.LastName}', '{customer.EmailAddress}', '{customer.PhoneNumber}'); ";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql,con))
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
        }
        public static int DeleteCustomerFromDb(int customerId)
        {
            var sql = $"delete from Customers where id={customerId}";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql, con))
                {
                    con.Open();
                    return com.ExecuteNonQuery();
                }
            }
        }
    }
}

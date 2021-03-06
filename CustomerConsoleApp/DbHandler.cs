﻿using System;
using System.Collections.Generic;
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
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No results found in the database");
                    }
                    
                    while (reader.Read())
                    {
                        int count = reader.FieldCount;
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write(reader.GetValue(i)+ " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void AddCustomerToDb(Customer c)
        {
            var sql = $"execute CreateCustomer '{c.FirstName}', '{c.LastName}', '{c.EmailAddress}'," +
                $"'{c.Address.Street}','{c.Address.Zipcode}','{c.Address.City}','{c.Address.Country}'";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql,con))
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateCustomerInDb(Customer customer, int customerId)
        {
            var sql = $"update Customers set first_name='{customer.FirstName}', last_name='{customer.LastName}'," +
                $" email_address='{customer.EmailAddress}', phonenumber='{customer.PhoneNumber}'" +
                $"where id={customerId}";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql, con))
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
        public static bool IsCustomerInDb(int customerId)
        {
            var sql = $"select id from Customers where id={customerId}";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql, con))
                {
                    
                    con.Open();
                    var reader = com.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public static Customer GetCustomerFromDb(int customerId)
        {
            var sql = $"select * from Customers where id={customerId}";
            using (var con = new SqlConnection(connstr))
            {
                using (var com = new SqlCommand(sql, con))
                {
                    con.Open();
                    var reader = com.ExecuteReader();
                    
                    reader.Read();
                    string firstName = reader.GetValue(1).ToString();
                    string lastName = reader.GetValue(2).ToString();
                    string emailAddress = reader.GetValue(3).ToString();
                    string phoneNumber = reader.GetValue(4).ToString();
                    //return new Customer(firstName, lastName, emailAddress, phoneNumber);
                    return new Customer();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleApp
{
    class UserInterface
    {
        /// <summary>
        /// Init the menu
        /// </summary>
        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-- Customer Database Console App --");
                Console.WriteLine("1. Add a new customer");
                Console.WriteLine("2. Delete a customer");
                Console.WriteLine("3. Update a customer");
                Console.WriteLine("4. List all customers");
                Console.WriteLine("5. Exit");
                int choice = AskForInt(": ");
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        Console.ReadKey();
                        break;
                    case 2:
                        DeleteCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        DbHandler.QueryDb("select id, first_name, last_name, email_address, phonenumber from Customers");
                        Console.ReadKey();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }

        }

        private static void UpdateCustomer()
        {

            int customerId = AskForInt("Customer id: ");
            if (DbHandler.IsCustomerInDb(customerId))
            {
                var customer = DbHandler.GetCustomerFromDb(customerId);
                Console.WriteLine("Enter data in fields to update, leave blank to ignore field");
                PrintGrey($"First name: {customer.FirstName}");
                string firstName = AskGreen(": ");
                if (!string.IsNullOrEmpty(firstName))
                {
                    customer.FirstName = firstName;
                }
                PrintGrey($"Last name: {customer.LastName}");
                string lastName = AskGreen(": ");
                if (!string.IsNullOrEmpty(lastName))
                {
                    customer.LastName = lastName;
                }
                PrintGrey($"Email: {customer.EmailAddress}");
                string email = AskGreen(": ");
                if (!string.IsNullOrEmpty(email))
                {
                    customer.EmailAddress = email;
                }
                PrintGrey($"Phonenumber: {customer.PhoneNumber}");
                string phoneNumber = AskGreen(": ");
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    customer.PhoneNumber = phoneNumber;
                }
                DbHandler.UpdateCustomerInDb(customer, customerId);
                Console.WriteLine("Update complete");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"No customer with id {customerId} exists in the database");
            }
            
        }

        private static void AddCustomer()
        {
            string firstName = AskGreen("First name: ");
            string lastName = AskGreen("Last name: ");
            string email = AskGreen("Email: ");
            string phoneNumber = AskGreen("Phonenumber: ");
            Customer customer = new Customer(firstName, lastName, email, phoneNumber);
            DbHandler.AddCustomerToDb(customer);
            Console.WriteLine($"{firstName} {lastName} was successfully added to the database");
        }
        private static void DeleteCustomer()
        {
            int customerId = AskForInt("Customer id: ");
            if (DbHandler.DeleteCustomerFromDb(customerId) == 1)
            {
                Console.WriteLine($"{customerId} deleted from database");
            }
            else
            {
                Console.WriteLine($"No customer with id {customerId} exists in the database");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Print output to console. Read Integer from user.
        /// </summary>
        /// <param name="question">Text to print </param>
        /// <returns>An interger from user</returns>
        private static int AskForInt(string question)
        {
            int answer = 0;
            bool isInt = false;
            do
            {
                Console.Write(question);
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    answer = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    isInt = true;
                }
                catch (FormatException)
                {
                    Console.ResetColor();
                    Console.WriteLine("Enter a number, try again");
                    Console.ReadKey();
                }
            } while (!isInt);
            return answer;
        }
        /// <summary>
        /// Print question to user. Read input (in green).
        /// </summary>
        /// <param name="question">Text to print </param>
        /// <returns>A string from user</returns>
        public static string AskGreen(string question)
        {
            Console.Write(question);
            Console.ForegroundColor = ConsoleColor.Green;
            string answer = Console.ReadLine();
            Console.ResetColor();
            return answer;
        }

        public static void PrintGrey(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}

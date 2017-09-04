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
                Console.WriteLine("2. List all customers");
                Console.WriteLine("3. Exit");
                int choice = AskForInt(": ");
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        Console.ReadKey();
                        break;
                    case 2:
                        DbHandler.QueryDb("select * from Customers");
                        Console.ReadKey();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }

        }

        private static void AddCustomer()
        {
            string firstName = AskGreen("First name: ");
            string lastName = AskGreen("Last name: ");
            string email = AskGreen("Email: ");
            string phoneNumber = AskGreen("Phonenumber: ");
            Customer customer = new Customer(firstName, lastName, email, phoneNumber);
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
                    answer = int.Parse(Console.ReadLine());
                    isInt = true;
                }
                catch (FormatException)
                {
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
    }
}

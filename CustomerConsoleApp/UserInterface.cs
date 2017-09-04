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
                        Console.WriteLine("Feature coming soon");
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

        /// <summary>
        /// Print output to console. Read Integer from user.
        /// </summary>
        /// <param name="output">Text to print </param>
        /// <returns>An interger from user</returns>
        private static int AskForInt(string output)
        {
            int answer = 0;
            bool isInt = false;
            do
            {
                Console.Write(output);
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
    }
}

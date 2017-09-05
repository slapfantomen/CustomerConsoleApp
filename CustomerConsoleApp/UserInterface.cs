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
                Console.WriteLine("4. Search for a customer");
                Console.WriteLine("5. List all customers");
                Console.WriteLine("6. Exit");
                int choice = AskForInt(": ");
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        DeleteCustomer();
                        break;
                    case 3:
                        UpdateCustomer();
                        break;
                    case 4:
                        SearchForCustomer();
                        break;
                    case 5:
                        ListAllCustomers();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }

        }

        private static void SearchForCustomer()
        {
            Console.Clear();
            Console.WriteLine("-- Search --");
            Console.WriteLine("1. First name");
            Console.WriteLine("2. Last name");
            Console.WriteLine("3. Email");
            Console.WriteLine("4. Phonenumber");
            Console.WriteLine("5. Back");
            int choice = AskForInt(": ");
            switch (choice)
            {
                case 1:
                    SearchDb(Validator.ValidateName, "First name: ", "first_name");
                    break;

                case 2:
                    SearchDb(Validator.ValidateName, "Last name: ", "last_name");
                    break;
                case 3:
                    SearchDb(Validator.ValidateEmail, "Email: ", "email_address");
                    break;
                case 4:
                    SearchDb(Validator.ValidatePhoneNumber, "Phone number: ", "phone_number");
                    break;
                default:
                    break;
            }
        }

        private static void SearchDb(Func<string,bool> validator, string query, string searchItem)
        {
            string str = EnterAndValidate(validator, query);
            DbHandler.QueryDb($"select * from Customers where {searchItem}='{str}'");
            Console.ReadKey();
        }

        private static void ListAllCustomers()
        {
            DbHandler.QueryDb("select id, first_name, last_name, email_address, phonenumber from Customers");
            Console.ReadKey();
        }

        private static void UpdateCustomer()
        {

            int customerId = AskForInt("Customer id: ");
            if (DbHandler.IsCustomerInDb(customerId))
            {
                var customer = DbHandler.GetCustomerFromDb(customerId);
                Console.WriteLine("Enter data in fields to update, leave blank to ignore field");
                Console.WriteLine("Invalid inputs will be ignored");
                PrintGrey($"First name: {customer.FirstName}");
                string firstName = AskGreen(": ");
                if (!string.IsNullOrEmpty(firstName))
                {
                    if (Validator.ValidateName(firstName))
                    {
                        customer.FirstName = firstName;
                    }   
                }
                PrintGrey($"Last name: {customer.LastName}");
                string lastName = AskGreen(": ");
                if (!string.IsNullOrEmpty(lastName))
                {
                    if (Validator.ValidateName(lastName))
                    {
                        customer.LastName = lastName;
                    }                  
                }
                PrintGrey($"Email: {customer.EmailAddress}");
                string email = AskGreen(": ");
                if (!string.IsNullOrEmpty(email))
                {
                    if (Validator.ValidateEmail(email))
                    {
                        customer.EmailAddress = email;
                    }                   
                }
                PrintGrey($"Phonenumber: {customer.PhoneNumber}");
                string phoneNumber = AskGreen(": ");
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    if (Validator.ValidatePhoneNumber(phoneNumber))
                    {
                        customer.PhoneNumber = phoneNumber;
                    }    
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
            string firstName = EnterAndValidate(Validator.ValidateName, "First name: ");
            string lastName = EnterAndValidate(Validator.ValidateName, "Last name: ");
            string email = EnterAndValidate(Validator.ValidateEmail,"Email: ");
            string phoneNumber = EnterAndValidate(Validator.ValidatePhoneNumber, "Enter phonenumber: ");
            Customer customer = new Customer(firstName, lastName, email, phoneNumber);
            DbHandler.AddCustomerToDb(customer);
            Console.WriteLine($"{firstName} {lastName} was successfully added to the database");
            Console.ReadKey();
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
        static string EnterAndValidate(Func<string, bool> validator, string query)
        {
            string str;
            do
            {
                str = AskGreen(query);

            } while (!validator(str));

            return str;
        }

        static void EditProperty(Customer customer, string s)
        {
            PrintGrey($"Email: {customer.EmailAddress}");
            string email = AskGreen(": ");
            if (!string.IsNullOrEmpty(email))
            {
                customer.EmailAddress = email;
            }
        }
    }
}

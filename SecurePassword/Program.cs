using SecurePassword.Models;
using SecurePassword.Security;
using System;
using System.Security.Cryptography;
using System.Threading;

namespace SecurePassword
{
    class Program
    {
        static bool CheckPassword(string username, string password)
        {
            PasswordHandler handler = new PasswordHandler();
            return handler.ValidatePassword(password, username);
        }

        static void Main(string[] args)
        {
            PasswordHandler handler = new PasswordHandler();
            bool running = true;
            
            int trys = 0;
            string input;
            while (running)
            {

                Console.WriteLine("Select a option:\n1. Login\n2. Create new account");

                
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Whats your user name?");
                        string username = Console.ReadLine();
                        Console.WriteLine("Whats your password?");
                        string password = Console.ReadLine();
                        Console.Clear();
                        if (CheckPassword(username, password))
                        {
                            Console.WriteLine($"Success\nWelcome {username}");
                            Console.Read();
                            running = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong user name or password");
                            trys++;
                            if (trys > 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Too many wrong answers");
                                running = false;
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("User name ?");
                        username = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Password ?");
                        password = Console.ReadLine();
                        handler.CreateUser(new User(username, password));
                        Console.Clear();
                        Console.WriteLine($"You have successfully created a account\nUser Name: {username}");
                        break;

                    default:
                        Console.WriteLine("Wrong input press any key to continue");
                        
                        break;
                }

            }




        }
    }
}

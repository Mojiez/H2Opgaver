using System;
using System.Text;
using App_Dal;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            //const string password = "V3ryC0mpl3xP455w0rd";
            //byte[] salt = Hash.GenerateSalt();

            //Console.WriteLine("Hash Password with Salt Demonstration in .NET");
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine();
            //Console.WriteLine("Password : " + password);
            //Console.WriteLine("Salt = " + Convert.ToBase64String(salt));
            //Console.WriteLine();

            //var hashedPassword1 = Hash.HashPasswordWithSalt(
            //    Encoding.UTF8.GetBytes(password),
            //    salt);

            //Console.WriteLine();
            //Console.WriteLine("Hashed Password = " + Convert.ToBase64String(hashedPassword1));
            //Console.WriteLine();

            //Console.ReadLine();

            string input = "hello";
            
            Console.WriteLine($"Input: {input} {"Begins with uppercase? ", 30}: " +
                              $"{(input.StartsWithUpper() ? "Yes" : "No")}\n");
        }
    }
}

using ASymetriskKryptering.RSA;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ASymetriskKryptering
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAGenerator generator = new RSAGenerator();
            
            Console.WriteLine("Ready to encrypt....");
         
            Console.WriteLine("Inset the modulus you what to use");
            string modulus = Console.ReadLine();
            
            Console.WriteLine("Inset the exponent you what to use");
            string exponent = Console.ReadLine();
           

            Console.WriteLine("Write a message to encrypt");
            string mess = Console.ReadLine();
            

            var mod = Encoding.UTF8.GetBytes(modulus);
            var expo = Encoding.UTF8.GetBytes(exponent);
            var encryptedText = generator.EncryptData(Encoding.UTF8.GetBytes(mess), mod, expo);
            
            
            Console.WriteLine(Convert.ToBase64String(encryptedText));
            Console.ReadKey();
            Console.Clear();
        }
    }
}

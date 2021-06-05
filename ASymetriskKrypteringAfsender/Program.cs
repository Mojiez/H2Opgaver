using ASymetriskKryptering.RSA;
using System;
using System.Security.Cryptography;

namespace ASymetriskKryptering
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAGenerator generator = new RSAGenerator();

            Console.WriteLine("Ready to send....");
            Console.Read();
            Console.WriteLine("Inset the modulus you what to use");
            string modulus = Console.ReadLine();

            Console.WriteLine("Inset the exponent you what to use");
            string exponent = Console.ReadLine();


            Console.WriteLine("Write a message to encrypt");
            string mess = Console.ReadLine();
            CspParameters parameters = new CspParameters();
            
            generator.AssignNewKey();



            Console.Clear();


        }
    }
}

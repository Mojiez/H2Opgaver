using Hash_Test.Hashing;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Hash_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            UserKey userKey = new UserKey(16);
            userKey.GenerateKey();

            HashHandler hash = new HashHandler();
            hash.HMACKey = UserKey.Key;

            string text = "Hello";
            byte[] hashedText = hash.GetHashedByteArray(text);

            Console.WriteLine(Convert.ToBase64String(hashedText));
            Console.WriteLine("Inset key");
            string input = Console.ReadLine();

            if (Convert.ToBase64String(hashedText) == Convert.ToBase64String(hash.GetHashedByteArray(input)))
            {
                Console.WriteLine("Success");
            }
            else
                Console.WriteLine("Error");

            Console.Read();


        }
    }
}

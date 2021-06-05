using System;
using System.Diagnostics;
using System.Text;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Console.WriteLine("Which hash do you want to use?");

            Console.WriteLine("1.HMAC\n2.SHA1\n3.SHA256\n4.SHA384\n5.SHA512\n6.MD5");

            input = Console.ReadLine();
            HashHandler hash = new HashHandler();

            switch (input)
            {
                case "1":
                    hash.HashType = Hashin.Types.HMAC;
                    break;

                case "2":
                    hash.HashType = Hashin.Types.SHA1;
                    break;

                case "3":
                    hash.HashType = Hashin.Types.SHA256;
                    break;

                case "4":
                    hash.HashType = Hashin.Types.SHA384;
                    break;

                case "5":
                    hash.HashType = Hashin.Types.SHA512;
                    break;

                case "6":
                    hash.HashType = Hashin.Types.MD5;
                    break;

                default:
                    break;
            }


            Console.Clear();
            if (hash.HashType == Hashin.Types.HMAC)
                Console.WriteLine("Your key is\n" + Encoding.ASCII.GetString(hash.HMACKey));
            Console.WriteLine("Write a password you want to hash");

            input = Console.ReadLine();
            string controleInput = input;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            byte[] hashedInput = hash.GetHashedByteArray(input);
            watch.Stop();
            Console.WriteLine(hash.HashType + " Hash Base 64 string Value: " + Convert.ToBase64String(hashedInput));
            Console.WriteLine($"HEX Value: {Convert.ToHexString(hashedInput)}");
            Console.WriteLine("ASCII Value: " + Encoding.ASCII.GetString(hashedInput));
            Console.WriteLine("Elapsed time in ticks: " + watch.ElapsedTicks);
            if (hash.HashType == Hashin.Types.HMAC)
            {
                Console.WriteLine("Insert password");
                string text = Console.ReadLine();
                // Checks the text by hashing it with the right key
                //Then it converts the hashed text to a string to see if it matches the saved string by the program
                                
                if (Convert.ToBase64String(hashedInput) == Convert.ToBase64String(hash.GetHashedByteArray(text)))
                {
                    //If it matches user will get a Success printed on screen
                    Console.WriteLine("Success");
                }
                else
                    //If it matches user will get a Wrong input printed on screen
                    Console.WriteLine("Wrong input");

                Console.WriteLine(hashedInput.Equals(hash.GetHashedByteArray(text)));
            }



        }
    }
}

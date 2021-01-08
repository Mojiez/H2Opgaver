using System;
using System.Text;

namespace SymetriskKryptering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("1. DES\n2. 3DES\n3. Rijndael");

            Encryption encryption = new Encryption();

            
            encryption.Generate(Console.ReadLine());

            Console.WriteLine("Write a text to encrypt");
            input = Console.ReadLine();
            byte[] message = encryption.Encrypt(Encoding.ASCII.GetBytes(input));
            Console.Clear();
            Console.WriteLine("Encrypted text: " + Convert.ToBase64String(message));

            byte[] newMessage = encryption.Decrypt(message);
            Console.WriteLine("Decrypted text: " + Encoding.ASCII.GetString(newMessage));
        }
    }
}

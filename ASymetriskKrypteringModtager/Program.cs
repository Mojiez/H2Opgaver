using ASymetriskKrypteringModtager.RSA;
using System;
using System.Text;

namespace ASymetriskKrypteringModtager
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateRSAKey key = new GenerateRSAKey();
            key.AssignNewKey();

            
            var mod = key.rsa.ExportParameters(false).Modulus;
            var exponent = key.rsa.ExportParameters(false).Exponent;

            Console.WriteLine("Modulus: " + Convert.ToBase64String(mod));
            Console.WriteLine("Exponent: " + Convert.ToBase64String(exponent));


            Console.WriteLine("Write a text you want to decrypt");
            string text = Console.ReadLine();
            var encryptedText = key.EncryptData(Encoding.UTF8.GetBytes(text));
            var decryptedText = key.DecryptData(encryptedText);

            Console.WriteLine(Convert.ToBase64String(encryptedText));
            Console.WriteLine(Convert.ToBase64String(decryptedText));

            key.DeleteKeyInCsp();
        }
    }
}

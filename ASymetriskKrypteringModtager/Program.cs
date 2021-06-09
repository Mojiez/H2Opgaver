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
            key.DeleteKeyInCsp();

            key.AssignNewKey();
            var rsaParams = GenerateRSAKey._rsa.ExportParameters(false);
            
            Console.WriteLine("Modulus: " + Convert.ToBase64String(rsaParams.Modulus));
            Console.WriteLine("Exponent: " + Convert.ToBase64String(rsaParams.Exponent));

            Console.WriteLine("Write a text you want to decrypt");
            string text = Console.ReadLine();
            
            var decryptedText = key.DecryptData(Encoding.UTF8.GetBytes(text));
            Console.WriteLine(Convert.ToBase64String(decryptedText));

        }
    }
}

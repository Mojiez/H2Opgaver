using System;
using System.Text;

namespace SymetriskKryptering
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Alfinans.Applications
    {
        internal class Program
        {
            public static GenerateCryptoKey ComboBox()
            {
                
                Console.WriteLine("What type of encryption ?\n1.DES\n2.3DES\n3.Rijndael 128bit\n4.Rijndael 256bit\n5.AES CSP 128bit\n6.AES CSP 256bit\n7.AESManaged 256bit\n8.AESManaged 128bit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        return new GenerateCryptoKey(Encryption.Type.DES);

                    case "2":
                        return new GenerateCryptoKey(Encryption.Type.TripleDES);

                    case "3":
                        return new GenerateCryptoKey(Encryption.Type.Rijndael128);

                    case "4":
                        return new GenerateCryptoKey(Encryption.Type.Rijndael256);

                    case "5":
                        return new GenerateCryptoKey(Encryption.Type.AESManaged256);

                    case "6":
                        return new GenerateCryptoKey(Encryption.Type.AESCSP128);

                    case "7":
                        return new GenerateCryptoKey(Encryption.Type.AESCSP256);

                    case "8":
                        return new GenerateCryptoKey(Encryption.Type.AESManaged128);

                    default:
                        return new GenerateCryptoKey(Encryption.Type.DES);

                }
            }

            private static void Main()
            {
                Stopwatch watch = new Stopwatch();
                Encryption encryption = new Encryption();
                watch.Start();

                GenerateCryptoKey cryptoKey = ComboBox();
                Console.WriteLine($"It took {watch.ElapsedMilliseconds}ms to generate key and iv");
                byte[] mess = new byte[16];
                string input;

                encryption.Generate(cryptoKey.KeyType);
                encryption.Key = cryptoKey.Key;
                encryption.IV = cryptoKey.IV;


                Console.WriteLine("Write a text to encrypt");
                input = Console.ReadLine();
                mess = Encoding.UTF8.GetBytes(input);
                Console.Clear();

                watch.Reset();
                watch.Start();
                var encryptedText = encryption.Encrypt(mess);
                Console.WriteLine($"Encryption time: {watch.ElapsedMilliseconds}ms with {encryption.EncryptionType}");
                watch.Reset();
                watch.Start();
                var decryptedText = encryption.Decrypt(encryptedText);
                Console.WriteLine($"Decryption time: {watch.ElapsedMilliseconds}ms with {encryption.EncryptionType}");

                Console.WriteLine("Encrypted text: " + Encoding.UTF8.GetString(encryptedText));
                Console.WriteLine("Decrypted text: " + Encoding.UTF8.GetString(decryptedText));

                Console.WriteLine();
            }
        }
    }
}

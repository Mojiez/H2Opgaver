using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SymetriskKryptering
{
    public class Encryption
    {
        SymmetricAlgorithm algorithm;
        
        public string ConvertInput(string cipher)
        {
            if (cipher == "1")
            {
                cipher = "DES";
            }
            else if (cipher == "2")
            {
                cipher = "3DES";
            }
            else
            {
                cipher = "Rijndael";
            }
            return cipher;
        }

        public void Generate(string cipher) 
        {
            cipher = ConvertInput(cipher);
            switch (cipher)
            {
                case "DES":
                    algorithm = DES.Create();
                    break;

                case "3DES":
                    algorithm = TripleDES.Create();
                    break;

                case "Rijndael":
                    algorithm = Rijndael.Create();
                    break;

                default:
                    break;
            }
            algorithm.GenerateIV();
            //algorithm.GenerateKey();
        }

        public byte[] Encrypt(byte[] message)
        {
            MemoryStream memory = new MemoryStream();
            CryptoStream crypto = new CryptoStream(memory, algorithm.CreateEncryptor(), CryptoStreamMode.Write);

            crypto.Write(message, 0, message.Length);
            crypto.Close();
            return memory.ToArray();
        }

        public byte[] Decrypt(byte[] message)
        {
            byte[] text = new byte[message.Length];

            MemoryStream memory = new MemoryStream(message);
            CryptoStream crypto = new CryptoStream(memory, algorithm.CreateDecryptor(), CryptoStreamMode.Read);

            crypto.Read(text, 0, message.Length);
            crypto.Close();

            return text;
        }
    }
}

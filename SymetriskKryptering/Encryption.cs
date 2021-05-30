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
        
        public enum Type
        {
            DES,
            TripleDES,
            Rijndael
        }
          
        public void Generate(Type type) 
        {
            
            switch (type)
            {
                case Type.DES:
                    algorithm = DES.Create();
                    break;

                case Type.TripleDES:
                    algorithm = TripleDES.Create();
                    break;

                case Type.Rijndael:
                    algorithm = Rijndael.Create();
                    break;

                default:
                    break;
            }
            algorithm.GenerateIV();
            algorithm.GenerateKey();
        }

        public byte[] ConvertToByte(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public string ConvertByteArrayToString(byte[] byteArray)
        {
            return Encoding.ASCII.GetString(byteArray);
        }

        public byte[] Encrypt(byte[] message)
        {
            MemoryStream memory = new MemoryStream();
            CryptoStream crypto = new CryptoStream(memory, algorithm.CreateEncryptor(), CryptoStreamMode.Write, false);

            crypto.Write(message, 0, message.Length);
            crypto.Close();
            return memory.ToArray();
        }

        public byte[] Decrypt(byte[] message)
        {
            byte[] text = new byte[message.Length];

            MemoryStream memory = new MemoryStream(message);
            CryptoStream crypto = new CryptoStream(memory, algorithm.CreateDecryptor(), CryptoStreamMode.Read, false);

            crypto.Read(text, 0, message.Length);
            crypto.Close();

            return text;
        }
    }
}

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
        public Type EncryptionType { get; private set; }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }

        
        public enum Type
        {
            DES,
            TripleDES,
            Rijndael256,
            Rijndael128,
            AESCSP128,
            AESCSP256,
            AESManaged128,
            AESManaged256
        }

        /// <summary>
        /// This method is used to instantiate a new algorithm
        /// </summary>
        /// <param name="type"></param>
        public void Generate(Type type)
        {
            switch (type)
            {
                case Type.DES:
                    EncryptionType = Type.DES;
                    algorithm = DES.Create();
                    break;
                case Type.TripleDES:
                    EncryptionType = Type.TripleDES;
                    algorithm = TripleDES.Create();
                    break;
                case Type.Rijndael256:
                    EncryptionType = Type.Rijndael256;
                    algorithm = Rijndael.Create();
                    break;
                case Type.Rijndael128:
                    EncryptionType = Type.Rijndael128;
                    algorithm = Rijndael.Create();
                    break;
                case Type.AESCSP128:
                    EncryptionType = Type.AESCSP128;
                    algorithm = Aes.Create();
                    break;
                case Type.AESCSP256:
                    EncryptionType = Type.AESCSP256;
                    algorithm = Aes.Create();
                    break;
                case Type.AESManaged128:
                    EncryptionType = Type.AESManaged128;
                    algorithm = AesManaged.Create();
                    break;
                case Type.AESManaged256:
                    EncryptionType = Type.AESManaged256;
                    algorithm = AesManaged.Create();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will encrypt the message  para and return a encrypted byte array 
        /// Make sure to set the Encryption type property
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] message)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                CryptoStream crypto = new CryptoStream(memoryStream, algorithm.CreateEncryptor(this.Key, this.IV), CryptoStreamMode.Write);
                crypto.Write(message, 0, message.Length);
                crypto.FlushFinalBlock();

                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new byte[16];
        }

        /// <summary>
        /// This method will decryot the message with the encryption type selected
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] message)
        {
            byte[] text = new byte[message.Length];

            //Creates a stream a memory i the ram
            MemoryStream memory = new MemoryStream(message);

            try
            {
                //Make the memory stream more secure by using a crypto stream
                CryptoStream crypto = new CryptoStream(memory, algorithm.CreateDecryptor(this.Key, this.IV), CryptoStreamMode.Read);
                crypto.Read(text, 0, message.Length);
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return text;
        }
    }
}

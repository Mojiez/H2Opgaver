using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SymetriskKryptering
{
    public class GenerateCryptoKey
    {
        public byte[] Key { get; private set; }
        public byte[] IV { get; private set; }
        public Encryption.Type KeyType { get; set; }
        int keyLength;
        int ivLength;

        public GenerateCryptoKey(Encryption.Type keyType)
        {
            KeyType = keyType;
            GenerateKeyAndIV();
        }

        /// <summary>
        /// Method used to set the key and iv size
        /// </summary>
        private void GenerateKeyAndIV()
        {
            switch (KeyType)
            {
                case Encryption.Type.DES:
                    keyLength = 8;
                    ivLength = 8;
                    break;

                case Encryption.Type.TripleDES:
                    keyLength = 16;
                    ivLength = 8;
                    break;

                case Encryption.Type.Rijndael256:
                    keyLength = 32;
                    ivLength = 16;
                    break;

                case Encryption.Type.Rijndael128:
                    keyLength = 16;
                    ivLength = 16;
                    break;
                case Encryption.Type.AESCSP128:
                    keyLength = 16;
                    ivLength = 16;
                    break;
                case Encryption.Type.AESCSP256:
                    keyLength = 32;
                    ivLength = 16;
                    break;
                case Encryption.Type.AESManaged128:
                    keyLength = 16;
                    ivLength = 16;
                    break;
                case Encryption.Type.AESManaged256:
                    keyLength = 32;
                    ivLength = 16;
                    break;
                default:
                    break;
            }
            Key = GenerateRandomByteArrray(keyLength);
            IV = GenerateRandomByteArrray(ivLength);
        }
        /// <summary>
        /// Generates a random byte array created by the rng crypto service provider
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] GenerateRandomByteArrray(int length)
        {
            using (RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider())
            {

                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SymetriskKryptering
{
    public class GenerateCryptoKey
    {
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }

        public GenerateCryptoKey(int keyLength, int ivLength)
        {
            GenerateKeyAndIV(keyLength, ivLength);
        }

        private void GenerateKeyAndIV(int keyLength, int ivLength)
        {
            Key = GenerateRandomByteArrray(keyLength);
            IV = GenerateRandomByteArrray(ivLength);
        }

        private byte[] GenerateRandomByteArrray(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public void GenerateNewKey(int keyLength, int ivLength)
        {
            GenerateKeyAndIV(keyLength, ivLength);
        }
    }
}

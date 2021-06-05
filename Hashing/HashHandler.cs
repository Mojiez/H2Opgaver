using Hashing.Hashin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class HashHandler
    {
        // To set the type of hash
        public Types HashType { get; set; }
        // To save the key used by HashHandler
        public byte[] HMACKey { get; set; }

        public HashHandler()
        {
            // Initialize a new byte array with a size of 16
            HMACKey = new byte[16];
            //For extra security at the cost of lower preformance
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Generates a random byte array with the same size of the array inputed in the parameter 
            rng.GetBytes(HMACKey);
        }

        /// <summary>
        /// Generates a hash value based on type set in the HashType property
        /// Returns a hashed byte array the the chosen type  
        /// </summary>
        /// <param name="textToBeHash"></param>
        /// <returns></returns>
        public byte[] GetHashedByteArray(string textToBeHash)
        {
            byte[] text = Encoding.UTF8.GetBytes(textToBeHash);

            switch (HashType)
            {
                case Types.SHA1:
                    return SHA1.HashData(text);

                case Types.MD5:
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    return md5.ComputeHash(text);

                case Types.SHA256:
                    return SHA256.HashData(text);

                case Types.SHA384:
                    return SHA384.HashData(text);

                case Types.SHA512:
                    return SHA512.HashData(text);

                case Types.HMAC:
                    HMACSHA256 hMACSHA256 = new HMACSHA256(HMACKey);
                    return hMACSHA256.ComputeHash(text);
                
                default:
                    return null;
            }

        }

        /// <summary>
        /// Checks if the hashed text matches the text
        /// Generates a new hash on the text, with the key to see, if there is a match
        /// Returns true if it matches
        /// </summary>
        /// <param name="hashText"></param>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool TestHMACKey(byte[] hashText, string text, byte[] key)
        {
            HMACSHA256 hMACSHA256 = new HMACSHA256(key);
            byte[] controleText = hMACSHA256.ComputeHash(Encoding.ASCII.GetBytes(text));

            for (int i = 0; i < hashText.Length; i++)
            {
                if(hashText[i] != controleText[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

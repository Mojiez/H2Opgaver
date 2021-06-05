using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Test
{
    public class HashHandler
    {
        public Types HashType { get; set; }
        public byte[] HMACKey { get; set; }

        public HashHandler()
        {
            HMACKey = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(HMACKey);
        }

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

        public bool TestHMACKey(byte[] hashText1, string text, byte[] key)
        {
            HMACSHA256 hMACSHA256 = new HMACSHA256(key);
            byte[] controleText = hMACSHA256.ComputeHash(Encoding.ASCII.GetBytes(text));

            for (int i = 0; i < hashText1.Length; i++)
            {
                if(hashText1[i] != controleText[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}

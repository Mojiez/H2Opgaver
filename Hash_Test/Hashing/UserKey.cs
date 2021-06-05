using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Test.Hashing
{
    public class UserKey
    {
        public static byte[] Key { get; private set; }
        public UserKey(int keyLength)
        {
            Key = new byte[keyLength];
        }

        public void GenerateKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(Key);
        }



    }
}

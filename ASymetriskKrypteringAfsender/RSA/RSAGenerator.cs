using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASymetriskKryptering.RSA
{
    public class RSAGenerator
    {
        const string ContainerName = "MyContainer";
    
        public byte[] EncryptData(byte[] dataToEncrypt, byte[] mod, byte[] expo)
        {
            byte[] cipherbytes;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsaParams = new RSAParameters();
            rsaParams.Modulus = mod;
            rsaParams.Exponent = expo;

            

            using (var rsa = new RSACryptoServiceProvider(4096, cspParams))
            {
                rsa.ImportParameters(rsaParams);
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }

    }
}

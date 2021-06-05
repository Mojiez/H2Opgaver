using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASymetriskKrypteringModtager.RSA
{
    public class GenerateRSAKey
    {
        const string ContainerName = "MyContainer";
        public RSACryptoServiceProvider rsa { get; set; }

        public void AssignNewKey()
        {
            CspParameters cspParameters = new CspParameters()
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = ContainerName
            };

            try
            {
                rsa = new RSACryptoServiceProvider(cspParameters);
            }
            catch (Exception ex)
            {
                CspParameters cspParams = new CspParameters(1);

                cspParams.KeyContainerName = ContainerName;
                cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
                cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
                rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = true };
            }
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        public byte[] EncryptData(byte[] dataToEncrypt)
        {
            byte[] cipherbytes;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                cipherbytes = rsa.Encrypt(dataToEncrypt, false);
            }

            return cipherbytes;
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            var cspParams = new CspParameters { KeyContainerName = ContainerName };

            using (var rsa = new RSACryptoServiceProvider(2048, cspParams))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }



    }

}

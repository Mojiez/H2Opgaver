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
                rsa = new RSACryptoServiceProvider(1024, cspParameters);
            }
            catch (Exception ex)
            {
                CspParameters cspParams = new CspParameters(1);

                cspParams.KeyContainerName = ContainerName;
                cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
                cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
                rsa = new RSACryptoServiceProvider(1024, cspParams) { PersistKeyInCsp = true };
            }
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        /// <summary>
        /// This method 
        /// </summary>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                plain = rsa.Decrypt(dataToDecrypt, false);
            }

            return plain;
        }
    }
}

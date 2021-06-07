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
        public RSACryptoServiceProvider _rsa { get; set; }

        public void AssignNewKey()
        {
            CspParameters cspParameters = new CspParameters()
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = ContainerName
            };

            try
            {
               _rsa = new RSACryptoServiceProvider(2048, cspParameters);
            }
            catch (Exception ex)
            {
            }
                CspParameters cspParams = new CspParameters(1);

                cspParams.KeyContainerName = ContainerName;
                cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
                cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
                _rsa = new RSACryptoServiceProvider(2048, cspParams) { PersistKeyInCsp = true };
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters { KeyContainerName = ContainerName };
            var rsa = new RSACryptoServiceProvider(cspParams) { PersistKeyInCsp = false };

            rsa.Clear();
        }

        public byte[] DecryptData(byte[] dataToDecrypt)
        {
            byte[] plain;

            //Ved ikke hvorfor den bliver ved med at smide en fejl på at min key er en ugldig længde
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.ImportParameters(this._rsa.ExportParameters(true));
                plain = rsa.Decrypt(dataToDecrypt, false);
            }
            return plain;
        }
    }
}

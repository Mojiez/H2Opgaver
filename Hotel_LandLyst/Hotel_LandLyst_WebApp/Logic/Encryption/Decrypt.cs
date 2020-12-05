using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Logic.Encryption
{
    public class Decrypt
    {
        // creates stream to "write" data
        MemoryStream memoryStream = new MemoryStream();

        // rijndael class
        RijndaelManaged rijndael = new RijndaelManaged();

        public string DecryptString(string input, string password, byte[] salt)
        {
            // derived bytes to make key and vector
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(password, salt);

            // key gets set
            rijndael.Key = rfc.GetBytes(32);

            // vector gets set
            rijndael.IV = rfc.GetBytes(16);
            rijndael.Padding = PaddingMode.PKCS7;
            // creates stream to "write" data            
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(), CryptoStreamMode.Write);

            // converts the encrypted string to bytes
            byte[] inputBytes = Convert.FromBase64String(input);

            // decrypts the bytes
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            // gets the decrypted bytes and converts them back to string
            byte[] output = memoryStream.ToArray();
            string result = Encoding.UTF8.GetString(output, 0, output.Length);

            // closes the streams
            cryptoStream.Close();
            memoryStream.Close();

            // returns the result
            return result;
        }
    }
}

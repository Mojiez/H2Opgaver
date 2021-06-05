using SecurePassword.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword.Security
{
    public class PasswordHandler
    {
        //For making calls to db
        SqlCommunication Communication;
        //The db connection make sure its the right connection string
        static SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=SecurePassword;Integrated Security=True");
        public PasswordHandler()
        {
            Communication = new SqlCommunication();
        }

        /// <summary>
        /// Validates the password
        /// Uses password to make a hash
        /// Makes a call to database to see if there is any users called userName ["Mark"]
        /// To get the hash and salt for creating a new hash
        /// If the new hash matches the database hash
        /// Returns true
        /// else false
        /// </summary>
        /// <param name="password"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidatePassword(string password, string userName)
        {
            if (Communication.GetHash(userName, connection) == Convert.ToBase64String(Hash(password + Communication.GetSalt(userName, connection))))
                return true;

            else if (Communication.GetHash(userName, connection) == Convert.ToBase64String(RfcHash(password, Communication.GetSalt(userName, connection))))
                return true;

            else
                return false;
        }
        /// <summary>
        /// Saves the user to a database
        /// Generates salt and hashed password 
        /// The inputed user only needs UserName and Password properties
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            user.Salt = GenerateSalt();
            //user.Password = Convert.ToBase64String(Hash(user.Password + user.Salt));
            user.Password = Convert.ToBase64String(RfcHash(user.Password, user.Salt));
            Communication.CreateUser(connection, user);
        }
        /// <summary>
        /// Creates a hash based on SHA256
        /// Converts the string to UTF8 byte array 
        /// The array converts to hash
        /// Returns hash in bytes
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] Hash(string text)
        {
            SHA256.Create();
            return SHA256.HashData(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// This hash method uses password based key derivation 
        /// PBKDF2
        /// And HMACSHA1
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public byte[] RfcHash(string password, string salt)
        {
            using (Rfc2898DeriveBytes hash = new Rfc2898DeriveBytes(Convert.FromBase64String(password), Convert.FromBase64String(salt), 100000))
            {
                return hash.GetBytes(64);
            }
        }

        /// <summary>
        /// Generates a random byte array based on RNGCryptoServiceProvider 
        /// Converts the byte array ToBase64String
        /// Returns the string
        /// </summary>
        /// <returns></returns>
        public string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

    }
}

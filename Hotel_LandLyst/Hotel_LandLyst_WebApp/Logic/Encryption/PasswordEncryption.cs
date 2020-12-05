using Hotel_LandLyst_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Logic.Encryption
{
    public class PasswordEncryption
    {
        private Decrypt decrypt = new Decrypt();
        private Encrypt encrypt = new Encrypt();
        private readonly string code = "HotelLandlyst";

        public EmployeeModel DecryptEmployeePassword(EmployeeModel employeeModel, byte[] salt)
        {
            employeeModel.Password = decrypt.DecryptString(employeeModel.Password, code, salt);
            return employeeModel;
        }

        public EmployeeModel EncryptEmployeePassword(EmployeeModel employeeModel)
        {
            byte[] randomSalt = CreateSalt();
            GiveEmployeeSalt(employeeModel, randomSalt);
            employeeModel.Password = encrypt.EncryptString(employeeModel.Password, code, randomSalt);
            return employeeModel;
        }

        public byte[] CreateSalt()
        {
            Random random = new Random();
            byte[] arr = new byte[10];
            random.NextBytes(arr);
            return arr;
        }

        public byte[] GetEmployeeSalt(EmployeeModel employeeModel)
        {
            string[] empsalt = employeeModel.Salt.Split(',');
            byte[] arr = new byte[empsalt.Length];
            for (int i = 0; i < empsalt.Length; i++)
            {
                arr[i] = byte.Parse(empsalt[i]);
            }
            return arr;
        }

        public EmployeeModel GiveEmployeeSalt(EmployeeModel employeeModel, byte[]salt)
        {
            for (int i = 0; i < salt.Length; i++)
            {
                if (salt.Length < i + 1)
                    employeeModel.Salt += salt[i].ToString() + ",";
                else
                    employeeModel.Salt += salt[i].ToString();
            }
            return employeeModel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class CostumerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }

        public CostumerModel(string firstName, string lastName, bool admin, string address, string postalCode, int phoneNumber, string email) 
        {
            FirstName = firstName;
            LastName = lastName;
            Admin = admin;
            Address = address;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public CostumerModel()
        { 
        }
        
    }
}

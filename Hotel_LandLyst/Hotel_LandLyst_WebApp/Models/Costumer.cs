using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class Costumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Costumer(int id, string name, string address, string postalCode, int phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}

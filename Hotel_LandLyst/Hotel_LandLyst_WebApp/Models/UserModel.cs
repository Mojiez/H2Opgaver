using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Admin { get; set; }

        public UserModel(string firstName, string lastName, bool admin)
        {
            FirstName = firstName;
            LastName = lastName;
            Admin = admin;
        }
    }
}

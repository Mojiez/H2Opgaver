using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class EmployeeModel : UserModel
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EmployeeModel(string firstName, string lastName, bool admin, string userName, string password, string title) : base(firstName, lastName, admin)
        {
            UserName = userName;
            Password = password;
            Title = title;
        }
    }
}

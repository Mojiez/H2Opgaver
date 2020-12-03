using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class EmployeeModel : UserModel
    {
        public EmployeeModel(string firstName, string lastName, bool admin) : base(firstName, lastName, admin)
        {
        }
    }
}

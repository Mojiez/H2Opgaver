using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class EmployeeModel : UserModel
    {
        public string Title { get; set; }
        public EmployeeModel(string firstName, string lastName, bool admin, string title) : base(firstName, lastName, admin)
        {
            Title = title;
        }
    }
}

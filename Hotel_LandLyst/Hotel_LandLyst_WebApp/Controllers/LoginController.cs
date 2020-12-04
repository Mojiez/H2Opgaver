using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration loginConfig;
        public LoginController(IConfiguration configuration)
        {
            loginConfig = configuration;
        }

        public IActionResult LoginPage()
        {
                return View();
        }

        [HttpPost]
        public IActionResult LoginPage(LoginModel loginModel)
        {
            List<EmployeeModel> employeeModels = DalManager.Manager.GetUser(loginConfig);
            EmployeeModel employee = employeeModels.Where(e => e.UserName == loginModel.Email && e.Password == loginModel.Password).FirstOrDefault();
            if (employee != null)
            {
                if (employee.Admin == true)
                    return Redirect("/Admin/Index");
            }

            return Redirect("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

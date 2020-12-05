using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Logic.Encryption;
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

        //Not working yet 
        [HttpPost]
        public IActionResult LoginPage(LoginModel loginModel)
        {
            PasswordEncryption passwordEncryption = new PasswordEncryption();
            List<EmployeeModel> employeeModels = DalManager.Manager.GetEmployees(loginConfig);
           
            return Redirect("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

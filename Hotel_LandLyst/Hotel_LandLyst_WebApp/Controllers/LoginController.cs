using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;

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
            
            
           
            return Redirect("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

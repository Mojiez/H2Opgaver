using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginPage()
        {
                return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginModel loginModel)
        {
            
           return Redirect("");
        }
    }
}

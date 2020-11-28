using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Hotel_LandLyst_WebApp.Controllers
{
    public class AdminController : Controller
    {
        private string conString; 
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateNewRoom()
        {

            return View(new );
        }
        

        public AdminController(IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("myConnection");
        }
    }
}

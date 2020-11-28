using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
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
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewRoom(RoomModel roomModel)
        {
            DalManager.Manager.SaveNewRoomToDataBase(roomModel, conString);
            return Redirect("Admin/Index");
        }
        

        public AdminController(IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("myConnection");
        }
    }
}

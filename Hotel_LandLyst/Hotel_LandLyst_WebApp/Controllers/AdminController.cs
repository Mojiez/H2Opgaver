using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Hotel_LandLyst_WebApp.Controllers
{
    public class AdminController : Controller
    {
        private IConfiguration Configuration;
        
        public IActionResult CreationSuccessPage()
        {
            return View(new SuccessModel());
        }

        public IActionResult Index()
        {
            return View();
        }

        //--------------------------------------CreateRoom
        [HttpGet]
        public IActionResult CreateNewRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewRoom(RoomModel roomModel, string price)
        {
            roomModel.PricePerNight = (float)Convert.ToDecimal(price);
            DalManager.Manager.SaveRoom(roomModel, Configuration);
            return Redirect("CreationSuccessPage");
        }
        //--------------------------------------------


        [HttpPost]
        public IActionResult CreateNewFurniture(FurnitureModel furnitureModel, string price)
        {
            furnitureModel.Price = (float)Convert.ToDecimal(price);
            DalManager.Manager.SaveNewFuniture(furnitureModel, Configuration);

            //Return a succes window
            return Redirect("CreationSuccessPage");
        }


        public AdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}

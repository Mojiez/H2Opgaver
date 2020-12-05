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

        public AdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult CreationSuccessPage(SuccessModel successModel)
        {
            return View(successModel);
        }

        public IActionResult RoomOrderView()
        {
            // GetDataFromDB
            OrderModel orderModel = new OrderModel() { Rooms = DalManager.Manager.GetRooms(Configuration) };
            foreach (var item in orderModel.Rooms)
            {
                item.CalculatePriceTotal();
            }
            return View(orderModel);
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
            return View("CreationSuccessPage", new SuccessModel() { RoomModel = roomModel });
        }
        //--------------------------------------------

        //--------------------------------------CreateNewFurniture
        [HttpGet]
        public IActionResult CreateNewFurniture()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewFurniture(FurnitureModel furnitureModel)
        {
            DalManager.Manager.SaveNewFuniture(furnitureModel, Configuration);
            return View("CreationSuccessPage", new SuccessModel() { FurnitureModel = furnitureModel });
        }


        //--------------------------------------CreateNewEmployee
        public IActionResult CreateNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewEmployee(EmployeeModel employeeModel)
        {
            //Upload employees to db
            return View();
        }
    }
}

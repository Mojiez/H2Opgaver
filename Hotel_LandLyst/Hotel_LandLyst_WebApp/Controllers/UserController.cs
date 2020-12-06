using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Web;
namespace Hotel_LandLyst_WebApp.Controllers
{
    //This class is responsible for user control
    public class UserController : Controller
    {
        private IConfiguration userConfiguration;
        public UserController(IConfiguration configuration)
        {
            userConfiguration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderPage()
        {
            OrderModel orderModel = new OrderModel() { Rooms = DalManager.Manager.GetRooms(userConfiguration) };
            foreach (var item in orderModel.Rooms)
            {
                item.CalculatePriceTotal();
            }
            return View(orderModel);
        }

        [HttpPost]
        public IActionResult OrderPage(OrderModel orderModel, List<int> roomNumbers)
        {
            return View();
        }

    }
}

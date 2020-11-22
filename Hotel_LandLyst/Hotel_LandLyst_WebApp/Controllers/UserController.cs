using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_LandLyst_WebApp.Controllers
{
    //This class is responsible for user control
    public class UserController : Controller
    {
        private static CostumerModel costumerModel;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderPage(OrderModel orderModel)
        {
            if(orderModel == null)
            return View(new OrderModel(costumerModel, ));
        }
    }
}

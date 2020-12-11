using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_LandLyst_WebApp.Dal;
using Hotel_LandLyst_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Web;
using System.Globalization;

namespace Hotel_LandLyst_WebApp.Controllers
{
    //This class is responsible for user control
    public class UserController : Controller
    {
        private static OrderModel order;
        private IConfiguration userConfiguration;
        public UserController(IConfiguration configuration)
        {
            userConfiguration = configuration;
        }

        //used for room selection for the user
        [HttpPost]
        public IActionResult OrderPage(OrderModel orderModel, int roomNumber)
        {
            if (order == null || order.Rooms.Count < 10)
            {
                order = new OrderModel() { Rooms = DalManager.Manager.GetRooms(userConfiguration), BookedRooms = new List<int>() };
                order.CheckInDate = orderModel.CheckInDate;
                order.CheckOutDate = orderModel.CheckOutDate;
                if (order.Rooms[0].PricePerNight <= 695)
                    foreach (var item in order.Rooms)
                    {
                        item.CalculatePriceTotal();
                    }
            }
            if (roomNumber != 0)
                order.BookedRooms.Add(roomNumber);

            orderModel = order;
            return View(orderModel);
        }

        //used to get renting period
        public IActionResult BookingPage()
        {
            return View(new OrderModel() { CheckInDate = DateTime.Now.Date, CheckOutDate = DateTime.Now.Date });
        }

        public IActionResult BookingConfirm()
        {
            List<RoomModel> controlList = new List<RoomModel>();
            foreach (var item in order.BookedRooms)
            {
                controlList.Add(order.Rooms.Where(x => x.Number == item).FirstOrDefault());
            }
            order.Rooms = controlList;
            order.RentingPeriod = order.CheckOutDate.Day - order.CheckInDate.Day;
            order.CalculatePriceTotal();
            return View(order);
        }

        public IActionResult BookingConfirmed(CostumerModel costumerModel)
        {
            order.Costumer = costumerModel;
            DalManager.Manager.SaveNewOrder(order, userConfiguration);
            return View();
        }

        public IActionResult CostumerInfo()
        {
            return View();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class OrderModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public CostumerModel Costumer { get; set; }
        public List<RoomModel> Room { get; set; }
        public double TotalPrice { get; set; }
        public int RentingPeriod { get; set; }

        public OrderModel(CostumerModel costumer, int daysRented)
        {
            CheckInDate = DateTime.Now;
            CheckOutDate = CheckInDate.AddDays(daysRented);
            Costumer = costumer;
            RentingPeriod = daysRented;
            Room = new List<RoomModel>();
        }

        public void CalculatePrice(List<RoomModel> rooms)
        {
            foreach (var item in rooms)
            {
                TotalPrice = item.PrizePerNight * RentingPeriod;
            }
        }
    }
}
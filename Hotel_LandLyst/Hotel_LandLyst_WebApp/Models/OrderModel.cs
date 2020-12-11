using Hotel_LandLyst_WebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class OrderModel : ICalculate
    {
        public int Number { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public CostumerModel Costumer { get; set; }
        public float TotalPrice { get; set; }
        public int RentingPeriod { get; set; }
        public List<RoomModel> Rooms { get; set; }
        public List<int> BookedRooms { get; set; }

        public OrderModel(CostumerModel costumer, int daysRented)
        {
            CheckInDate = DateTime.Now.Date;
            CheckOutDate = DateTime.Now.Date;
            Costumer = costumer;
            RentingPeriod = daysRented;
        }

        public OrderModel()
        {
        }

        public float CalculatePriceTotal()
        {
            TotalPrice = 0;
            foreach (var item in Rooms)
            {
                for (int i = 0; i < RentingPeriod; i++)
                {
                    TotalPrice += item.PricePerNight;
                }
            }
            if (RentingPeriod > 6)
            {
                TotalPrice -= TotalPrice * 0.1f;
            }
            return TotalPrice;
        }
    }
}

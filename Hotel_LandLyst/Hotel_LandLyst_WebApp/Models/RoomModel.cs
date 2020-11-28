using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class RoomModel
    {
        public bool Status { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public int RoomNumber { get; set; }
        public double PricePerNight { get; private set; } 

        public RoomModel(bool status, List<Furniture> furnitures, int roomNumber, double pricePerNight)
        {
            PricePerNight = pricePerNight;
            Status = status;
            Furnitures = furnitures;
            RoomNumber = roomNumber;
            CalculatePriceTotal();
        }
        private void CalculatePriceTotal()
        {
            foreach (var item in Furnitures)
            {
                PricePerNight += item.Price;
            }
        }
    }
}

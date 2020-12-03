using Hotel_LandLyst_WebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class RoomModel : ICalculate
    {
        public int Number { get; set; }
        public bool Clean { get; set; }
        public bool Rented { get; set; }
        public float PricePerNight { get; set; } 
        public List<FurnitureModel> Furnitures { get; set; }

        public RoomModel(bool clean, bool rented, List<FurnitureModel> furnitures, int number, float pricePerNight)
        {
            PricePerNight = pricePerNight;
            Clean = clean;
            Rented = rented;
            Furnitures = furnitures;
            Number = number;
            CalculatePriceTotal();
        }

        public RoomModel()
        {
        }

        public float CalculatePriceTotal()
        {
            foreach (var item in Furnitures)
            {
                PricePerNight += item.Price;
            }
            return PricePerNight;
        }
    }
}

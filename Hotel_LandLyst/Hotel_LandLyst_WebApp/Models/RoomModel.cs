using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class RoomModel
    {
        
        public int Id { get; set; }
        public char Category { get; set; }
        public double PrizePerNight { get; set; }
        public ExtraEquipment ExtraEquipment { get; set; }

        public RoomModel(char category, double prizePerNight, ExtraEquipment extraEquipment)
        {
            Category = category;
            PrizePerNight = prizePerNight;
            ExtraEquipment = extraEquipment;
        }

        public double CalculatePricePerNight(ExtraEquipment extraEquipment)
        {
            double price = 0;

            

            return price;
        }

        
    }
}

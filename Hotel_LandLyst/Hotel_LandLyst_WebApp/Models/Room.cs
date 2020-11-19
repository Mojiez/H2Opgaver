using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public char Category { get; set; }
        public double PrizePerNight { get; set; }
        public ExtraEquipment ExtraEquipment { get; set; }

        public Room(char category, double prizePerNight, ExtraEquipment extraEquipment)
        {
            Category = category;
            PrizePerNight = prizePerNight;
            ExtraEquipment = extraEquipment;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class RoomModel
    {
        public bool Status { get; set; }
        public ExtraEquipment ExtraEquipment { get; set; }
        public int RoomNumber { get; set; }
        public double PricePerNight { get; set; }
        public RoomModel(bool status, double pricePerNight, ExtraEquipment extraEquipment, int roomNumber)
        {
            Status = status;
            PricePerNight = pricePerNight;
            ExtraEquipment = extraEquipment;
            RoomNumber = roomNumber;
        }
    }
}

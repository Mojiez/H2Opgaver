using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class ExtraEquipment
    {
        public int PriceTotal { get; private set; }
        public bool Balconi { get; set; }
        public bool DoubleBed { get; set; }
        public bool Tub { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Kitchen { get; set; }

        public ExtraEquipment(bool balconi, bool doubleBed, bool tub, bool jacuzzi, bool kitchen)
        {
            Balconi = balconi;
            DoubleBed = doubleBed;
            Tub = tub;
            Jacuzzi = jacuzzi;
            Kitchen = kitchen;
            GetEquipmentPrice();
        }

        /// <summary>
        /// Used to Calculate the price for extra equipment
        /// </summary>
        private void GetEquipmentPrice()
        {
            if (Balconi == true)
            {
                PriceTotal += 150;
            } 
            if(DoubleBed == true)
            {
                PriceTotal += 200;
            }
            if (Tub == true)
            {
                PriceTotal += 50;
            }
            if (Jacuzzi == true)
            {
                PriceTotal += 175;
            }
            if (Kitchen == true)
            {
                PriceTotal += 350;
            }
        } 
    }
}

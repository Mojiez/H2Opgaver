using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class ExtraEquipment
    {
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
        }
    }
}

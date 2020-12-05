using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class FurnitureModel
    {
        public int Id { get; set; }

        [DisplayName("Tilbehør")]
        public string Name { get; set; }
        [DisplayName("Pris")]
        public float Price { get; set; }

        public FurnitureModel()
        {

        }
        public FurnitureModel(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}

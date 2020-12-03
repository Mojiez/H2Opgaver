using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class FurnitureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public FurnitureModel(int id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}

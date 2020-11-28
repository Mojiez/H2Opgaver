using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Furniture(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_LandLyst_WebApp.Models
{
    public class SuccessModel
    {
        public CostumerModel CostumerModel { get; set; }
        public FurnitureModel FurnitureModel { get; set; }
        public RoomModel RoomModel { get; set; }
        public EmployeeModel EmployeeModel { get; set; }
    }
}

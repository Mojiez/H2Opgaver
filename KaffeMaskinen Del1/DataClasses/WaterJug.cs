using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class WaterJug : Container
    {
        public WaterJug(int size, string contentType = "Water") : base(size, contentType)
        {
        }
    }
}

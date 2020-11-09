using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class CoffeeJug : Container
    {
        public CoffeeJug(int size, string contentType) : base(size, contentType)
        {
        }

    }
}

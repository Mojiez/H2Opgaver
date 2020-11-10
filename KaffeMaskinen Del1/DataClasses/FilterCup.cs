using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class FilterCup : Container
    {
        public FilterCup(int size, string contentType = "CoffeePowder") : base(size, contentType)
        {
        }
    }
}

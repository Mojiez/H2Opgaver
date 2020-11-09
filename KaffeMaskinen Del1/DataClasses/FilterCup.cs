using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class FilterCup : Container, IHandle
    {
        public FilterCup(int size, string contentType) : base(size, contentType)
        {
        }

        public void EmptyOut()
        {
            Quantity = 0;
        }

        public void FillUp(int quantity)
        {
            Quantity = quantity;
        }
    }
}

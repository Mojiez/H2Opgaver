using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class CoffeeJug : Container, IHandle
    {
        public CoffeeJug(int size, string contentType) : base(size, contentType)
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Geometrics
{
   public class Square
    {
        private float side;

        public float Side
        {
            get { return side; }
            set { side = value; }
        }

        public float CalculateArea()
        {
            return side * side;
        }

        public float CalculatePerimeter()
        {
            return (side + side) * 2;
        }

        public Square (float side)
        {
            Side = side;
        }
    }
}

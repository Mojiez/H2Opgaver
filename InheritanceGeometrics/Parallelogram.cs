using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceGeometrics
{
    class Parallelogram : Square
    {
        private double heightB;
        private int degrees;

        protected int Degrees
        {
            get { return degrees; }
            set { degrees = value; }
        }

        protected double HeightB
        {
            get { return heightB; }
            set { heightB = value; }
        }

        public Parallelogram(double lengthA, double heightB, int degrees) : base(lengthA)
        {
            HeightB = heightB;
            Degrees = degrees;
        }

        public override double CalculateArea()
        {
            return (LengthA * HeightB) * Math.Sin((20 * Math.PI) / 180);
        }
    }
}

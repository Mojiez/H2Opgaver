using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceGeometrics
{
    class Triangle : Form
    {
        private double heigthB;
        private double lengthC;

        protected double LengthC
        {
            get { return lengthC; }
            set { lengthC = value; }
        }

        protected double HeigthB
        {
            get { return heigthB; }
            set { heigthB = value; }
        }

        public Triangle(double lengthA, double heigthB, double lengthC) : base(lengthA)
        {
            HeigthB = heigthB;
            LengthC = lengthC;
        }
        public override double CalculatePerimeter()
        {
            return LengthA + HeigthB + LengthC;  
        }
        public override double CalculateArea()
        {
            return 0.5 * LengthA * HeigthB;
        }
    }
}

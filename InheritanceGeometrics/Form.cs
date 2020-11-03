using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceGeometrics
{
    class Form
    {
        private double lenghtA;
        protected double LengthA
        {
            get { return lenghtA; }
            set { lenghtA = value; }
        }
        protected Form(double lengthA)
        {
            LengthA = lengthA;
        }
        public virtual double CalculatePerimeter()
        {
            return LengthA * 4;
        }
        public virtual double CalculateArea()
        {
            return Math.Pow(LengthA, 2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceGeometrics
{
    class Trapez : Square
    {
        private double heigthB;
        private double lengthC;
        private double heigthD;
        private double heigthH;
        private double s;
        protected double S
        {
            get { return s; }
            set { s = value; }
        }
        protected double HeigthH
        {
            get { return heigthH; }
            set { heigthH = value; }
        }
        protected double HeigthD
        {
            get { return heigthD; }
            set { heigthD = value; }
        }
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

        public Trapez(double lengthA, double heigthB, double lengthC, double heightD) : base(lengthA)
        {
            HeigthB = heigthB;
            LengthC = lengthC;
            HeigthD = heigthB;
            S = (LengthA + HeigthB - LengthC + HeigthD) / 2;
            HeigthH = (2 / (LengthA - LengthC)) * (Math.Sqrt(S * (S - LengthA + LengthC) * (S - HeigthB) * (S - HeigthD)));
        }
        public override double CalculateArea()
        {
            return (0.5 * (LengthA + LengthC)) * HeigthH;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceGeometrics
{
	class Square : Form
	{
		public Square(double lengthA) : base(lengthA)
		{
		}
		public override double CalculatePerimeter()
		{
			return LengthA * 4;
		}
		public override double CalculateArea()
		{
			return Math.Pow(LengthA, 2);
		}
	}
}

using System;
using System.Collections.Generic;

namespace InheritanceGeometrics
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(20);
            Square square = new Square(10);
            Parallelogram parallelogram = new Parallelogram(3, 5, 20);
            Trapez trapez = new Trapez(10, 9, 8, 9);
            Triangle triangle = new Triangle(10, 10, 10);
            List<Form> forms = new List<Form>();
            
            forms.Add(rectangle);
            forms.Add(square);
            forms.Add(parallelogram);
            forms.Add(trapez);
            forms.Add(triangle);
            triangle.CalculateArea();
            foreach (Form item in forms)
            {
                Console.WriteLine(item.CalculateArea());
                Console.WriteLine(item.CalculatePerimeter());
            }
        }
    }
}

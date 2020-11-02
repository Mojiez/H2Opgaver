using System;

namespace Geometrics
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(2);
            

            Console.WriteLine(square.CalculatePerimeter());

            Square square1 = new Square(5);
            Square square2 = new Square(10);

            Console.WriteLine(square1.CalculateArea());
            Console.WriteLine(square2.CalculateArea());


        }
    }
}

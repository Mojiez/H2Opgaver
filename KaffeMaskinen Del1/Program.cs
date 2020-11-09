using KaffeMaskinen.DataClasses;
using System;

namespace KaffeMaskinen
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine("Hd10", 10, 10, 5, 5, new WaterJug(2), new CoffeeJug(2), new FilterCup(4));

            coffeeMachine.TurnOn();
            coffeeMachine.WaterJug.FillUp(100);
            coffeeMachine.FilterCup.FillUp(100);
            coffeeMachine.Start();


        }
    }
}

using KaffeMaskinen.DataClasses;
using System;

namespace KaffeMaskinen
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine("Hd10", 10, 10, 5, 5, new WaterJug(2), new CoffeeJug(2), new FilterCup(4), new Grinder("Hd10", 2, 2, 5, 1, new IngredientContainer(2, "")));

            coffeeMachine.TurnOn();
            coffeeMachine.WaterJug.FillUp(100, "Water");
            coffeeMachine.Grinder.IngredientContainer.FillUp(100, "CoffeeBeans");
            coffeeMachine.Start(0);

            Console.WriteLine(coffeeMachine.CoffeeJug.ContentType.ToString() + " " + coffeeMachine.CoffeeJug.Quantity);
        }
    }
}

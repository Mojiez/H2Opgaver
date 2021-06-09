using CoffeeMachine.Containers;
using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IngredientJug cup = new IngredientJug();

            cup.FillUp(Ingredients.CoffeeBeans, 50);

            Console.Read();
        }
    }
}

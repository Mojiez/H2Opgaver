using CoffeeMachine_App.Containers;
using CoffeeMachine_App.Data;
using CoffeeMachine_App.Machines;
using System;
using System.Collections.Generic;

namespace CoffeeMachine_App
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine("", "");
            Console.WriteLine("Select a type of ingredient");
            // The GetNames method turns the enum into a string array
            for (int i = 1; i < Enum.GetNames(typeof(Ingredients)).Length + 1; i++)
            {
                // Gives a menu for all the available ingredients with numbercount
                Console.WriteLine($"{i}.{(Ingredients)i - 1 }");
            }

            string input = Console.ReadLine();

            Console.WriteLine("How many cups ?");
            string numberOfCups = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // First the coffeeMachine object is called
                    // To get the IngredientContainer object then it gets casted into a IngredientContainer
                    // Then the ingredient from the container is set
                    ((IngredientContainer)coffeeMachine.IngredientContainer).Ingredient = Ingredients.None;
                    // First the coffeeMachine IngredientContainer object gets casted into a WaterContainer
                    // Then the ingredient from the container is set
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine("Here is your hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                case "2":
                    ((IngredientContainer)coffeeMachine.IngredientContainer).Ingredient = Ingredients.None;
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine($"Here is your {numberOfCups} cups of hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                case "3":
                    ((IngredientContainer)coffeeMachine.IngredientContainer).Ingredient = Ingredients.CoffeePowder;
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine($"Here is your {numberOfCups} cups of hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                default:
                    break;
            }
        }
    }
}

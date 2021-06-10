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
            Console.WriteLine("Select a type of hot drink");
            // The GetNames method turns the enum into a string array
            for (int i = 1; i < Enum.GetNames(typeof(HotDrinks)).Length + 1; i++)
            {
                // Gives a menu for all the available ingredients with numbercount
                Console.WriteLine($"{i}.{(HotDrinks)i - 1 }");
            }

            string input = Console.ReadLine();

            Console.WriteLine("How many cups ?");
            string numberOfCups = Console.ReadLine();
            switch (input)
            {
                case "1":
                    // First the coffeeMachine object is called
                    // To get the Container object from the coffeeMachine object, then it gets casted into a CoffeeContainer
                    // Then the HotDrink from the container is set
                    ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink = HotDrinks.Water;
                    
                    // First the coffeeMachines Container object gets casted into a WaterContainer
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine("Here is your hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                case "2":
                    ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink = HotDrinks.Coffee;
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine($"Here is your {numberOfCups} cups of hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                case "3":
                    ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink = HotDrinks.Tea;
                    ((WaterContainer)coffeeMachine.WaterContainer).CupValue = Convert.ToInt32(numberOfCups);
                    coffeeMachine.TurnOn();
                    Console.WriteLine($"Here is your {numberOfCups} cups of hot " + ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink);
                    break;

                case "4":
                    ((CoffeeContainer)coffeeMachine.CoffeeContainer).HotDrink = HotDrinks.Espresso;
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

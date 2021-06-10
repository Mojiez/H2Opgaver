using CoffeeMachine_App.Containers;
using CoffeeMachine_App.Data;
using CoffeeMachine_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Machines
{
    // This class is a machine but now the machine can make some hot coffee
    public class CoffeeMachine : Machine, IBrew
    {
        bool turnedOn;
        public Container CoffeeContainer { get; set; }
        public Container IngredientContainer { get; set; }
        public Container WaterContainer { get; set; }

        // Because CoffeeMachine inherits from machine we need the empty construktor
        // Its not realy empty, it just uses the base construktor aka Machine
        public CoffeeMachine(string name, string model) : base(name, model)
        {
            CoffeeContainer = new CoffeeContainer();
            IngredientContainer = new IngredientContainer();
            WaterContainer = new WaterContainer();
        }

        /// <summary>
        /// Useses the water from the water container
        /// warms is up then pour it over the ingredient container to make the hot drink :)
        /// </summary>
        /// <returns></returns>
        public void Brew()
        {
            // Here the ingredient is set based on the hot drink selected from the CoffeeContainer
            switch (((CoffeeContainer)CoffeeContainer).HotDrink)
            {
                case HotDrinks.Water:
                    ((IngredientContainer)IngredientContainer).Ingredient = Ingredients.None;
                    break;

                case HotDrinks.Coffee:
                    ((IngredientContainer)IngredientContainer).Ingredient = Ingredients.CoffeePowder;
                    break;

                default:
                    break;
            }
            // while to controle the brew stops when the water container is empty or the machine TurnedOn is false
            while (WaterContainer.CupValue > 0 && turnedOn)
            {
                // To simulate that its brewing 
                Thread.Sleep(10);
                Console.Clear();
                WaterContainer.CupValue--;
                CoffeeContainer.CupValue++;
                Console.WriteLine("Brewing..");

            }
            TurnOff();
        }

        /// <summary>
        /// Used to turn on the machine 
        /// </summary>
        public void TurnOff()
        {
            turnedOn = Switch();
            Console.WriteLine("Turn off");
        }

        /// <summary>
        /// Used to turn off the machine
        /// </summary>
        public void TurnOn()
        {
            Console.WriteLine("Turn on");
            turnedOn = Switch();
            Brew();
        }
    }
}

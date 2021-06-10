using CoffeeMachine_App.Data;
using CoffeeMachine_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Containers
{
    // This class is responsible for keeping the ingredient
    public class IngredientContainer : Container, IRemove, IHoldIngredients
    {
        Ingredients _ingredient;
        public Ingredients Ingredient { get => _ingredient; set => _ingredient = value; }

        /// <summary>
        /// Made to simulate the change of ingredient container
        /// So that you can take the container out from the coffee machine
        /// </summary>
        /// <param name="container"></param>
        public void InsertContainer(Container container)
        {
            CupValue = container.CupValue;
        }

        /// <summary>
        /// The method returns the running instance of the object
        /// </summary>
        /// <returns></returns>
        public Container RemoveContainer()
        {
            return this;
        }
    }
}

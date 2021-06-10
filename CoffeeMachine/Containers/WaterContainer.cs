using CoffeeMachine_App.Data;
using CoffeeMachine_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Containers
{
    // This class is responsible for keeping water 
    public class WaterContainer : Container, IDispenseWater, IRemove, IHoldIngredients
    {
        // Made so that the water container only takes water  
        Ingredients ingredient = Ingredients.Water;
        //Uses the property from the interface therefor we need a field to satisfy the inplementation (contract) 
        public Ingredients Ingredient { get => ingredient; }

        /// <summary>
        /// Method that empties the water container slowly, to make the right type of hot drink
        /// </summary>
        /// <returns></returns>
        public int Dispense()
        {
            int dispensedWater = Convert.ToInt32(CupValue * 0.1);
            CupValue -= dispensedWater;
            return dispensedWater;
        }

        /// <summary>
        /// Place a container with content
        /// </summary>
        /// <param name="container"></param>
        public void InsertContainer(Container container)
        {
            CupValue = container.CupValue;
        }

        /// <summary>
        /// Made to simulate the change of Water container
        /// So that you can take the container out from the coffee machine
        /// </summary>
        /// <param name="container"></param>
        public Container RemoveContainer()
        {
            return this;
        }
    }
}

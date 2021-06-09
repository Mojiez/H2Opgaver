using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Containers
{
    public class IngredientJug : Jug
    {
        // To set the ingredient used to make the hot fluid
        public static Ingredients Ingredient { get; set; }

        /// <summary>
        /// This method is used to fill the cup
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="amountOfTheIngredient"></param>
       

    }
}

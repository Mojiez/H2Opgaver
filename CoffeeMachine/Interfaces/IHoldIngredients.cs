using CoffeeMachine_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Interfaces
{
    // Used to set a ingredients property on the containers
    public interface IHoldIngredients
    {
        // Needs this as a field on implementation
        public Ingredients Ingredient { get; }
    }
}

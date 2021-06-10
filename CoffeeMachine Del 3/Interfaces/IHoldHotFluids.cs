using CoffeeMachine_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Interfaces
{
    // Used to set a HotDrink property on the containers
    public interface IHoldHotFluids
    {
        // Needs this as a field on implementation
        HotDrinks HotDrink { get; set; }
    }
}

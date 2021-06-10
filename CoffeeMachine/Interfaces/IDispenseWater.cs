using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Interfaces
{
    // This interface is used by containers to dispense water 
    public interface IDispenseWater
    {
        // Method that the other child classes have to implement to make the polymorphic feature to work
        int Dispense();
    }
}

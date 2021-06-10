using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Interfaces
{
    // This interface i used to emulate a brewing machine
    public interface IBrew
    {
        // Methods that the classes have to implement to make the polymorphic feature to work
        // Class that implements this can now be a IBrew
        // Example: IBrew polymorphicFeatureObject = new CoffeeMachine();
        void TurnOff();
        void TurnOn();
        void Brew();
    }
}

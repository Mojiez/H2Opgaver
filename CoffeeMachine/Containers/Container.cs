using CoffeeMachine_App.Data;
using CoffeeMachine_App.Interfaces;
using System;

namespace CoffeeMachine_App.Containers
{
    // This class represents the base container
    public abstract class Container 
    {
        // To set a maximum on the cup
        public static int maxValue = 100;

        // To set a minimum on the cup
        public static int minValue = 0;

        // To have a cup value that the coffeemachine reads on to make the right coffee strength 
        public int CupValue { get; set; }
        
       
    }
}

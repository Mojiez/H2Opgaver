using CoffeeMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Containers
{
    // This class represents the base jug
    public abstract class Jug : IFillUp
    {
        // To set a maximum on the cup
        public static int maxValue = 100;
        // To set a minimum on the cup
        public static int minValue = 0;
        // To have a cup value that the coffeemachine reads on to make the right coffee strength 
        public static int CupValue { get; set; }

        public void FillUp(Ingredients ingredient, int amount)
        {
            throw new NotImplementedException();
        }
    }
}

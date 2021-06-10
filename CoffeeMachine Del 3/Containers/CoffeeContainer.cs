using CoffeeMachine_App.Data;
using CoffeeMachine_App.Interfaces;

namespace CoffeeMachine_App.Containers
{
    // This class represents the coffee jug/container
    public class CoffeeContainer : Container, IRemove, IHoldHotFluids
    {
        HotDrinks hotDrink;
        public HotDrinks HotDrink { get => hotDrink; set => hotDrink = value; }

        /// <summary>
        /// Made to simulate the change of coffee container
        /// So that you can take the container out from the coffee machine
        /// </summary>
        /// <param name="container"></param>
        public void InsertContainer(Container container)
        {
            this.CupValue = container.CupValue;
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

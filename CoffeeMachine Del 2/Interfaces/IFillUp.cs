using CoffeeMachine_App.Data;

namespace CoffeeMachine_App.Interfaces
{
    // This interface is responsible for changeing content inside the containers 
    public interface IFillUp
    {
        // Methods that the other child classes have to implement to make the polymorphic feature to work
        /// <summary>
        /// Fills up the container with the amount of and the ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <param name="amount"></param>
        void FillUp(Ingredients ingredient, int amount);
        
        /// <summary>
        /// Empties out the amount and the ingredients
        /// </summary>
        /// <returns></returns>
        Ingredients EmptyOut();
    }
}

using CoffeeMachine_App.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Interfaces
{
    // This class make it possible for containers to be removed
    public interface IRemove
    {
        // Methods that the other child classes have to implement to make the polymorphic feature to work
        /// <summary>
        /// Removes the container 
        /// and returns it
        /// </summary>
        /// <returns></returns>
        Container RemoveContainer();
        /// <summary>
        /// Insert the new container 
        /// </summary>
        /// <param name="container"></param>
        void InsertContainer(Container container);
    }
}

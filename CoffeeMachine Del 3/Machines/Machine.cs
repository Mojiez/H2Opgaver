using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_App.Machines
{
    // This class is used to represent a machine
    public class Machine
    {
        // To have the state only inside this class
        private bool turnedOn;
        // The set happens internally(through the switch method)
        // Has a default on false
        private bool TurnedOn { set => Switch(); }
        // String to get the machine name
        // Set happens on initialization 
        public string Name { get; private set; }
        // String to get the machine model
        // Set happens on initialization
        public string Model { get; private set; }
        // The contrucktor is used to initialize or instantiate this class as an object
        // It has two string perameters one for the name property and the other for the machine model property 
        public Machine(string name, string model)
        {
            //When the contruktor is called i.e when a new instance is made, the Name from the parameter will be set here 
            Name = name;
            // And the machine model will be set here as name
            Model = model;
        }

        /// <summary>
        /// This method is protected so only this class and its children can call it 
        /// Method used to turn on and off
        /// Default is false
        /// Flips between true and false
        /// </summary>
        /// <returns></returns>
        protected bool Switch()
        {
            // Check for true so the machine cant be turned on twice
            if (turnedOn == true)
            {
                // If the condition from, the if statement is true
                // the it sets the property to false
                turnedOn = false;
                // returns false, because the machine is turned off
                return false;
            }
            else
            {
                // If the condition from, the if statement is false
                // the it sets the property to true
                turnedOn = true;
                // and then it returns a true, because now the machine is on
                return true;
            }    
        }
    }
}

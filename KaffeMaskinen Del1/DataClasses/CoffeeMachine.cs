using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    //This class is responsible for 
    class CoffeeMachine : Machine, IMachine
    {
        private bool turnedOn;
        public bool TurnedOn
        {
            get { return turnedOn; }
            set { turnedOn = value; }
        }

        private CoffeeJug coffeeJug;
        public CoffeeJug CoffeeJug
        {
            get { return coffeeJug; }
            set { coffeeJug = value; }
        }

        private FilterCup filterCup;
        public FilterCup FilterCup
        {
            get { return filterCup; }
            set { filterCup = value; }
        }

        private WaterJug waterJug;
        public WaterJug WaterJug
        {
            get { return waterJug; }
            set { waterJug = value; }
        }

        public CoffeeMachine(string model, float height, float width, float depth, float weight, WaterJug waterJug, CoffeeJug coffeeJug, FilterCup filterCup) : base(model, height, width, depth, weight)
        {
            WaterJug = waterJug;
            CoffeeJug = coffeeJug;
            FilterCup = filterCup;
        }
        /// <summary>
        /// This method starts the coffeemachine if its turned on!
        /// </summary>
        public void Start()
        {
            if(TurnedOn == true)
            {
                CoffeeJug.FillUp(WaterJug.Quantity);
            }
        }
        /// <summary>
        /// Turns on the power 
        /// </summary>
        public void TurnOn()
        {
            TurnedOn = true;
        }
        /// <summary>
        /// Turns off the power
        /// </summary>
        public void TurnOff()
        {
            TurnedOn = false;
        }
    }
}

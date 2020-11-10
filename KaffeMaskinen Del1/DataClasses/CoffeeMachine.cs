using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    //This class is responsible for 
    class CoffeeMachine : Machine, IPower
    {
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

        private Grinder grinder;

        public Grinder Grinder
        {
            get { return grinder; }
            set { grinder = value; }
        }

        public CoffeeMachine(string model, float height, float width, float depth, float weight, WaterJug waterJug, CoffeeJug coffeeJug, FilterCup filterCup, Grinder grinder) : base(model, height, width, depth, weight)
        {
            WaterJug = waterJug;
            CoffeeJug = coffeeJug;
            FilterCup = filterCup;
            Grinder = grinder;
        }
        /// <summary>
        /// This method starts the coffeemachine if its turned on!
        /// </summary>
        public void Start(int ingredient)
        {
            if (TurnedOn == true)
            {
                Grinder.TurnOn();
                FilterCup.ContentType = Grinder.Grind(ingredient).ToString();
                CoffeeJug.FillUp(WaterJug.Quantity, FilterCup.ContentType);
            }
            Grinder.TurnOff();
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

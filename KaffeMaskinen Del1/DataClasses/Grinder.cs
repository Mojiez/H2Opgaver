using KaffeMaskinen.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class Grinder : Machine, IPower
    {
        private IngredientContainer ingredientContainer;
        public IngredientContainer IngredientContainer
        {
            get { return ingredientContainer; }
            set { ingredientContainer = value; }
        }

        public Grinder(string model, float height, float width, float depth, float weight, IngredientContainer ingredientContainer) : base(model, height, width, depth, weight)
        {
            IngredientContainer = ingredientContainer;
        }

        public Powder Grind(int ingredient)
        {
            return new Powder((IngredientList)ingredient + " " + "Powder" );
        }

        public void TurnOff()
        {
            TurnedOn = false;
        }

        public void TurnOn()
        {
            TurnedOn = true;
        }
    }
}

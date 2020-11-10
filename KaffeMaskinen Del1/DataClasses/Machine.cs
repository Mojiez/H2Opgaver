using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    //This class represents a machine object
    public class Machine
    {
        private string model;
        private float height;
        private float width;
        private float depth;
        private float weight;
        
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private bool turnedOn;

        public bool TurnedOn
        {
            get { return turnedOn; }
            set { turnedOn = value; }
        }

        public Machine(string model, float height, float width, float depth, float weight)
        {
            Model = model;
            Height = height;
            Width = width;
            Depth = depth;
            Weight = weight;
            TurnedOn = false;
        }
    }
}

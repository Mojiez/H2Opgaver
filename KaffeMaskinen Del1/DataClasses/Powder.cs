using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.DataClasses
{
    public class Powder
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Powder(string name)
        {
            Name = name;
        }
    }
}

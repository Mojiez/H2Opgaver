using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.Interface
{
    //This handles the machines main function
    interface IMachine
    {
        public void TurnOn();
        public void TurnOff();
        public void Start();
    }
}

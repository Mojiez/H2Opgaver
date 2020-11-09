using System;
using System.Collections.Generic;
using System.Text;

namespace KaffeMaskinen.Interface
{
    interface IHandle
    {
        public void FillUp(int quantity);
        public void EmptyOut();
    }
}

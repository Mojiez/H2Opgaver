using System;
using System.Collections.Generic;
using System.Text;

namespace BagageSorting.CheckIns
{
    public class Bagage
    {
        public int Number { get; set; }
        public TimeSpan CheckInStamp { get; set; }
        public TimeSpan CheckOutStamp { get; set; }
       
        public Bagage()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BagageSorting.FlightPlaning
{
    public class FlightPlan
    {
        public TimeSpan FlightDeparture { get; set; }
        public int GateNumber { get; set; }

        public override string ToString()
        {
            return $"Departure on gate {GateNumber} takeoff at {FlightDeparture.Hours}:{FlightDeparture.Minutes}:{FlightDeparture.Seconds}";
        }
    }
}

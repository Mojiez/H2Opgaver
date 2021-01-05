using System;

namespace BagageSorting.Reservations
{
    public class Reservation
    {
        public TimeSpan Departure { get; set; }
        public string Name { get; set; }
        public int PassangerNumber { get; set; }
        private static int IdCheccUp { get; set; }

        public Reservation()
        {
            PassangerNumber = IdCheccUp;
            IdCheccUp++;
        }

        public override string ToString()
        {
            return $"Departure: {Departure.Hours}:{Departure.Minutes} - Name: {Name} - Passanger Number: {PassangerNumber}";
        }
    }
}

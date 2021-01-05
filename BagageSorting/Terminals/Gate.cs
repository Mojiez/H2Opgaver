using BagageSorting.CheckIns;
using BagageSorting.FlightPlaning;
using BagageSorting.Interfaces;
using BagageSorting.Reservations;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BagageSorting.Terminals
{
    public class Gate : ITimeStamp
    {
        public int Number { get; set; }
        public FlightPlan flightPlan;
        public List<Reservation> reservations;
        public States State;

        public Gate()
        {
            reservations = new List<Reservation>();
        }

        public void CheckInReservations()
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                Stamp(new Bagage() { Number = reservations[i].PassangerNumber });
                Console.WriteLine($"Passanger checkin at gate{Number}");
            }
        }

        public void Open()
        {
            while (State == States.Open)
            {
                if (reservations.Count > 0)
                    CheckInReservations();
                else
                    Closed();
            }
        }

        public void Closed()
        {
            while (State == States.Closed)
            {
                Thread.Sleep(100);
            }
        }

        public Bagage Stamp(Bagage bagage)
        {
            DateTime time = DateTime.UtcNow;
            bagage.CheckInStamp = new TimeSpan(time.Hour, time.Minute, time.Second);
            return bagage;
        }
    }
}

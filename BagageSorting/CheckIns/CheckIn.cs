using BagageSorting.Interfaces;
using BagageSorting.Reservations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BagageSorting.CheckIns
{
    public class CheckIn : ITimeStamp
    {
        public List<Reservation> reservations;
        private List<Bagage> bagages;
        public static States State;
        public int Number { get; set; }
        private Stopwatch stopwatch = new Stopwatch();
        private TimeSpan time = new TimeSpan(0, 1, 0);

        public CheckIn()
        {
            reservations = new List<Reservation>();
            bagages = new List<Bagage>();
        }

        public void Open()
        {
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < time.TotalMilliseconds)
            {
                GetReservertionsForNextTakeOff();
            }
            Close();
        }

        public void Close()
        {
            State = States.Closed;
        }

        public void GetReservertionsForNextTakeOff()
        {
            for (int i = 0; i < reservations.Count; i++)
            {
                if(reservations[].Departure == )
                Stamp(new Bagage() { Number = reservations[i].PassangerNumber });
                Console.WriteLine($"Passanger checkin bag at checkin {Number}");
            }
        }

        public Bagage Stamp(Bagage bagage)
        {
            DateTime date = DateTime.UtcNow;
            bagage.CheckInStamp = new TimeSpan(date.Hour, date.Minute, date.Second);
            return bagage;
        }
    }
}

using BagageSorting.Interfaces;
using BagageSorting.Reservations;
using System;
using System.Collections.Generic;

namespace BagageSorting.CheckIns
{
    public class CheckIn : ITimeStamp
    {
        public List<Reservation> reservations;
        public List<Bagage> bagages;
        public static States States;

        public CheckIn()
        {
            reservations = new List<Reservation>();
            bagages = new List<Bagage>();
        }

        public void GetReservertionsForNextTakeOff()
        {
            foreach (var item in bagages)
            {
                Stamp(item);
            }
        }

        public void CheckInBags(ReservationManager reservationManager)
        {
            ReservationManager.State = States.Closed;
            GetReservertionsForNextTakeOff();
        }

        public Bagage Stamp(Bagage bagage)
        {
            DateTime date = DateTime.UtcNow;
            bagage.CheckInStamp = new TimeSpan(date.Hour, date.Minute, date.Second);
            return bagage;
        }
    }
}

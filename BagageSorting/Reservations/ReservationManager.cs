using BagageSorting.CheckIns;
using BagageSorting.FlightPlaning;
using BagageSorting.Terminals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BagageSorting.Reservations
{
    public class ReservationManager
    {
        public List<FlightPlan> Departures { get; set; }
        private CheckIn[] CheckIns;
        public static States State { get; set; }
        static Stopwatch stopwatch;
        private TimeSpan timespan = new TimeSpan(0, 5, 0);
        private Gate[] _gates;

        private FlightPlan[] Gate1FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(16, 25, 00), GateNumber = 1 }, new FlightPlan() { FlightDeparture = new TimeSpan(18, 10, 0), GateNumber = 1 }, new FlightPlan() { FlightDeparture = new TimeSpan(20, 15, 0), GateNumber = 1 } };
        private FlightPlan[] Gate2FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(12, 25, 00), GateNumber = 2 }, new FlightPlan() { FlightDeparture = new TimeSpan(16, 45, 0), GateNumber = 2 }, new FlightPlan() { FlightDeparture = new TimeSpan(14, 35, 0), GateNumber = 2 } };
        private FlightPlan[] Gate3FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(17, 25, 00), GateNumber = 3 }, new FlightPlan() { FlightDeparture = new TimeSpan(22, 15, 0), GateNumber = 3 }, new FlightPlan() { FlightDeparture = new TimeSpan(23, 55, 0), GateNumber = 3 } };
        readonly string[] fNames = { "Jan", "Dan", "Anton", "Børge", "Jasmin", "Lone", "Bente", "Kim", "Tove" };
        readonly string[] lNames = { "Nilsen", "Henningsen", "Hansen", "Jensen", "Mikkelsen", "Thorsen", "Therkildsen" };
        private int gate1Count = 0, gate2Count = 0, gate3Count = 0;

        public ReservationManager(CheckIn[] checkIns)
        {
            CheckIns = checkIns;
        }

        public void ChangeDepartures(object flightLock)
        {
            Random random = new Random();
            Departures = new List<FlightPlan>();

            stopwatch = new Stopwatch();
            lock (flightLock)
            {
                Departures = new List<FlightPlan>() { Gate1FlightPlans[random.Next(3)], Gate2FlightPlans[random.Next(3)], Gate3FlightPlans[random.Next(3)] };
                for (int i = 0; i < _gates.Length; i++)
                {
                    _gates[i].flightPlan = Departures[i];
                }
            }
            foreach (var item in Departures)
            {
                Console.WriteLine(item.ToString());
            }

            stopwatch.Start();
            State = States.Open;
            Open(flightLock, _gates);
        }

        /// <summary>
        /// This method will open the system to reservations
        /// </summary>
        public void Open(object flightLock, Gate[] gates)
        {
            _gates = gates;
            while (stopwatch.ElapsedMilliseconds < timespan.TotalMilliseconds)
            {
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Thread.Sleep(100);
                if (State == States.Closed)
                {
                    Closed(flightLock);
                }
                RandomReservationCreation(flightLock);
            }
            ChangeDepartures(flightLock);
        }

        /// <summary>
        /// This method keeps the reservation manager thread i sleep mode 
        /// Takes a fligtLock object to ensure that the manager have a lock to prevent a dead lock
        /// </summary>
        /// <param name="flightLock"></param>
        public void Closed(object flightLock)
        {
            while (State == States.Closed)
            {
                Thread.SpinWait(10);
            }
            ChangeDepartures(flightLock);
        }

        /// <summary>
        /// This method is making random reservations and sends them to SendReservationsToCheckIn
        /// </summary>
        /// <param name="flightLock"></param>
        public void RandomReservationCreation(object flightLock)
        {
            Random random = new Random();
            Reservation reservation = new Reservation() { Departure = Departures[random.Next(3)].FlightDeparture, Name = fNames[random.Next(7)] + " " + lNames[random.Next(7)], PassangerNumber = random.Next(99999) };
            
            lock (flightLock)
            {
                Console.WriteLine(reservation.ToString());
                SendReservationToCheckIn(reservation);
            }
            Open(flightLock, _gates);
        }

        /// <summary>
        /// This method sends the reservations to the checkin
        /// </summary>
        /// <param name="reservation"></param>
        private void SendReservationToCheckIn(Reservation reservation)
        {
            for (int i = 0; i < _gates.Length; i++)
            {
                if (reservation.Departure == _gates[i].flightPlan.FlightDeparture && _gates[i].reservations.Count < 150)
                {
                    _gates[i].reservations.Add(reservation);
                }
            }
        }
    }
}

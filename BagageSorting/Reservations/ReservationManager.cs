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
        public static States State { get; set; }
        static Stopwatch stopwatch;

        private CheckIn[] _checkIns;
        private TimeSpan timespan = new TimeSpan(0, 5, 0);
        private Gate[] _gates;
        private int[] checkCount = { 0, 0, 0 };
        private FlightPlan[] Gate1FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(16, 25, 00), GateNumber = 1 }, new FlightPlan() { FlightDeparture = new TimeSpan(18, 10, 0), GateNumber = 1 }, new FlightPlan() { FlightDeparture = new TimeSpan(20, 15, 0), GateNumber = 1 } };
        private FlightPlan[] Gate2FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(12, 25, 00), GateNumber = 2 }, new FlightPlan() { FlightDeparture = new TimeSpan(16, 45, 0), GateNumber = 2 }, new FlightPlan() { FlightDeparture = new TimeSpan(14, 35, 0), GateNumber = 2 } };
        private FlightPlan[] Gate3FlightPlans = { new FlightPlan() { FlightDeparture = new TimeSpan(17, 25, 00), GateNumber = 3 }, new FlightPlan() { FlightDeparture = new TimeSpan(22, 15, 0), GateNumber = 3 }, new FlightPlan() { FlightDeparture = new TimeSpan(23, 55, 0), GateNumber = 3 } };
        private object _Lock;

        readonly string[] fNames = { "Jan", "Dan", "Anton", "Børge", "Jasmin", "Lone", "Bente", "Kim", "Tove" };
        readonly string[] lNames = { "Nilsen", "Henningsen", "Hansen", "Jensen", "Mikkelsen", "Thorsen", "Therkildsen" };

        public ReservationManager(CheckIn[] checkIns)
        {
            _checkIns = checkIns;
        }

        public void ChangeDepartures()
        {
            Random random = new Random();
            Departures = new List<FlightPlan>();

            stopwatch = new Stopwatch();
            lock (_Lock)
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
            Open(_Lock, _gates, _checkIns);
        }

        /// <summary>
        /// This method will open the system to reservations
        /// </summary>
        public void Open(object flightLock, Gate[] gates, CheckIn[] checkIns)
        {
            _checkIns = checkIns;
            _gates = gates;
            _Lock = flightLock;
            if (Departures == null || Departures.Count == 0)
            {
                ChangeDepartures();
            }
            while (stopwatch.ElapsedMilliseconds < timespan.TotalMilliseconds)
            {
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                Thread.Sleep(100);
                if (State == States.Closed || checkCount[0] == 150 && checkCount[1] == 150 && checkCount[2] == 150)
                {
                    ThreadPool.QueueUserWorkItem((WaitCallback) =>
                    {
                        _checkIns[0].Open();
                        _checkIns[0].Open();
                        _checkIns[0].Open();
                    });
                    State = States.Closed;
                    Closed();
                }
                RandomReservationCreation(flightLock);
            }
            ChangeDepartures();
        }

        /// <summary>
        /// This method keeps the reservation manager thread i sleep mode 
        /// Takes a fligtLock object to ensure that the manager have a lock to prevent a dead lock
        /// </summary>
        /// <param name="flightLock"></param>
        public void Closed()
        {
            while (State == States.Closed)
            {
                Thread.SpinWait(10);
            }
            ChangeDepartures();
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
            Open(flightLock, _gates, _checkIns);
        }

        /// <summary>
        /// This method sends the reservations to the checkin
        /// </summary>
        /// <param name="reservation"></param>
        private void SendReservationToCheckIn(Reservation reservation)
        {
            for (int i = 0; i < _checkIns.Length; i++)
            {
                if (reservation.Departure == _gates[i].flightPlan.FlightDeparture && checkCount[i] < 150)
                {
                    _checkIns[i].reservations.Add(reservation);
                    checkCount[i]++;
                }
            }
            Open(_Lock, _gates, _checkIns);
        }
    }
}

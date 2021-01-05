using BagageSorting.CheckIns;
using BagageSorting.Reservations;
using BagageSorting.Sorting;
using BagageSorting.Terminals;
using System.Threading;

namespace BagageSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = new object();
            CheckIn[] checkIns = { new CheckIn() { Number = 1 }, new CheckIn() { Number = 2 }, new CheckIn() { Number = 3 } };
            ReservationManager resevationManager = new ReservationManager(checkIns);
            SortingManager sortingManager = new SortingManager();
            Gate[] gates = { new Gate() { Number = 1 }, new Gate() { Number = 2 }, new Gate() { Number = 3 } };

            while (true)
            {
                ThreadPool.QueueUserWorkItem((WaitCallback) =>
                {
                    resevationManager.Open(o, gates, checkIns);
                });
            }

        }
    }
}

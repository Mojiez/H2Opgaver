using BagageSorting.CheckIns;
using BagageSorting.Reservations;
using BagageSorting.Sorting;
using System.Threading;

namespace BagageSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = new object();
            CheckIn[] checkIns = { new CheckIn(), new CheckIn(), new CheckIn() };
            ReservationManager resevationManager = new ReservationManager(checkIns);
            SortingManager sortingManager = new SortingManager();

            

        }
    }
}

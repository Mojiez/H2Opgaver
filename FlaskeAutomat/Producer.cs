using System;
using System.Collections.Generic;
using System.Threading;

namespace FlaskeAutomat
{
    public class Producer
    {
        public static bool Asleep;
        public static Queue<Bottle> Bottles = new Queue<Bottle>();
        public static string[] itemTypes = { "Beer", "Soda" };
        public void ProducerDoWork(object itemLock)
        {
            Random random = new Random();
            while (true)
            {
                lock (itemLock)
                {
                    while (Bottles.Count < 5)
                    {
                        Bottle bottle = new Bottle() { name = itemTypes[random.Next(2)] };
                        Console.WriteLine($"Producer added {bottle.name}");
                        Bottles.Enqueue(bottle);
                    }
                }

                Asleep = true;
                ProducerSleep();
            }

        }

        public static void ProducerSleep()
        {
            while (Asleep == true)
            {
                Thread.Sleep(10);
            }
        }
    }
}

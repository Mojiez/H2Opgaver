using System;
using System.Collections.Generic;
using System.Threading;

namespace FlaskeAutomat
{
    class Splitter
    {
        public static Queue<Bottle> sodaBottles = new Queue<Bottle>();
        public static Queue<Bottle> beerBottles = new Queue<Bottle>();

        public void Split(object itemLock)
        {
            while (true)
            {
                while (sodaBottles.Count < 5 || beerBottles.Count < 5)
                {
                    Queue<Bottle> copyList = Producer.Bottles;
                    lock (itemLock)
                    {
                        for (int i = 0; i < copyList.Count; i++)
                        {
                            Bottle bottle = Producer.Bottles.Dequeue();
                            if (bottle.name == "Soda")
                            {
                                Console.WriteLine("Split Soda");
                                sodaBottles.Enqueue(bottle);
                            }
                            else
                            {
                                Console.WriteLine("Split Beer");
                                beerBottles.Enqueue(bottle);
                            }
                        }

                        Producer.Asleep = false;
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}

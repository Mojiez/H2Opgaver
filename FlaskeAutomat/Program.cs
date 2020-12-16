using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FlaskeAutomat
{
    public class Bottle
    {
        public string name;
    }
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
                Thread.Sleep(100);
            }
        }
    }

    class Splitter
    {
        public static Queue<Bottle> sodaBottles = new Queue<Bottle>();
        public static Queue<Bottle> beerBottles = new Queue<Bottle>();

        public void Split(object itemLock)
        {
            while (true)
            {
                while (sodaBottles.Count < 2 || beerBottles.Count < 2)
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

    class Consumer
    {
        public Bottle Bottle;
        public string TypeOfDrink;

        public void BuyABottle(object itemLock)
        {
            lock (itemLock)
            {
                if (TypeOfDrink == "Soda")
                {
                    Bottle = Splitter.sodaBottles.Dequeue();
                    Console.WriteLine("Consumer grabed Soda");
                }
                else
                {
                    Bottle = Splitter.beerBottles.Dequeue();
                    Console.WriteLine("Consumer grabed Beer");
                }
            }
        }
    }


    class Program
    {
        private static Queue<Bottle> bottles = new Queue<Bottle>();
        private static object itemLock = new object();

        static void Main(string[] args)
        {
            Producer producer1;
            Splitter splitter1;
            Console.WriteLine(Producer.Asleep);
            Thread producer = new Thread(() =>
            {
                producer1 = new Producer();
                producer1.ProducerDoWork(itemLock);
            });
            producer.Start();

            Thread.Sleep(300);
            Thread splitter = new Thread(() =>
            {
                splitter1 = new Splitter();
                splitter1.Split(itemLock);
            });
            splitter.Start();
            Thread.Sleep(100);

            Random random = new Random();
            while (true)
            {
                Thread consumer = new Thread(() =>
                {
                    Consumer consumer1 = new Consumer() { TypeOfDrink = Producer.itemTypes[random.Next(2)] };
                    consumer1.BuyABottle(itemLock);
                });
                consumer.Start();
                Thread.Sleep(100);
            }


        }
    }
}

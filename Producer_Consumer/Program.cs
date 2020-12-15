using System;
using System.Threading;

namespace Producer_Consumer
{

    class Item
    {

    }

    static class ItemConsumer
    {
        public static bool ASleep { get; set; }
    }

    static class ItemProducer
    {
        public static bool ASleep { get; set; }
    }


    class Program
    {
        static Item[] basket = new Item[10];
        static int itemCount = 0;
        static object controlLock = new object();
        static object consumer = new object();


        static void Main(string[] args)
        {
            int consumerCount = 0;
            Thread producer = new Thread(Producer);
            producer.Start();
            Thread.Sleep(100);
            while (true)
            {
                if (itemCount > 0)
                {
                    Thread consumer = new Thread(Consumer);
                    consumerCount++;
                    consumer.Start();
                    Console.WriteLine($"new consumer number {consumerCount} enters");
                }
            }
        }

        public static void Consumer()
        {

            Random random = new Random();
            int itemnumber = random.Next(10);
            lock (consumer)
            {
                while (basket[itemnumber] == null)
                {
                    itemnumber = random.Next(10);
                }
                if (itemCount < 2)
                {
                    Console.WriteLine("consumer waits for items");
                    Thread.Sleep(300);
                }
                Console.WriteLine($"consumer chose item {itemnumber}");
                if (ItemProducer.ASleep == true)
                {
                    lock (controlLock)
                    {
                        basket[itemnumber] = null;
                        Console.WriteLine("Consumer bought an item");
                        itemCount--;
                        Console.WriteLine(itemCount);
                        if (itemCount == 0)
                        {
                            Console.WriteLine("consumer calls the producer");
                            WakeUp();
                        }
                    }

                }
            }

        }

        private static void Sleep()
        {
            ItemProducer.ASleep = true;
            Console.WriteLine("Producer going home to sleep");
            while (ItemProducer.ASleep == true)
            {
                Thread.Sleep(1);
            }
        }

        private static void WakeUp()
        {
            ItemProducer.ASleep = false;
            Console.WriteLine("Producer going to work");

        }

        private static void Producer()
        {
            while (true)
            {

                lock (controlLock)
                {
                    for (int i = 0; i < basket.Length; i++)
                    {
                        if (basket[i] == null)
                        {
                            basket[i] = new Item();
                            itemCount++;
                            Console.WriteLine($"Producer added an item to the basket\nitems in basket: {itemCount}");
                        }

                    }
                }
                Sleep();

            }

        }
    }
}

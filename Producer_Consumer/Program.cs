using System;
using System.Collections.Generic;
using System.Threading;

namespace Producer_Consumer
{
    class Producer
    {
        public static int ItemsProduced { get; set; }
        public static bool IsRunning { get; set; }
        public static object key { get; set; } = new object();
        public static Stack<Item> Items { get; set; } = new Stack<Item>();


        public static void Produce()
        {
            if (Monitor.TryEnter(key))
            {
                while (Items.Count < 5)
                {

                    Monitor.Enter(key);

                    Console.WriteLine("Producer work");
                    Items.Push(new Item());
                    Monitor.PulseAll(key);
                    Monitor.Exit(key);
                    Thread.Sleep(500);

                }
            }
            Monitor.Enter(key);
            Monitor.Wait(key);
            Produce();
        }
    }

    class Consumer
    {
        public static object key { get; set; } = new object();

        public static void Consume()
        {
            if (Monitor.TryEnter(Producer.key))
            {
                if (Producer.Items.Count > 1)
                {
                    Monitor.Enter(Producer.key);
                    if (Producer.Items.Count > 0)
                    {
                        Producer.Items.Pop();
                        Console.WriteLine("Consumer Consumes");
                        Monitor.PulseAll(Producer.key);
                    }

                    Monitor.Exit(Producer.key);
                }
                else
                {
                    Monitor.Enter(Producer.key);
                    Monitor.Wait(Producer.key);
                }

            }
            Thread.Sleep(10);
            Consume();
        }
    }


    class Item
    {

    }

    class Program
    {
        static Stack<Item> basket = new Stack<Item>();
        static int itemCount = basket.Count;
        static object controlLock = new object();

        static void Main(string[] args)
        {


            Thread thread = new Thread(Producer.Produce);

            Thread thread1 = new Thread(Consumer.Consume);

            thread.Start();
            thread1.Start();

            Console.Read();

        }
    }
}


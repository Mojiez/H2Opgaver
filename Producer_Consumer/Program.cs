using System;
using System.Collections.Generic;
using System.Threading;

namespace Producer_Consumer
{
    class Producer
    {
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

    // Used to define a object
    class Item
    {

    }
    
    // Start point of the program
    class Program
    {
        static void Main(string[] args)
        {

            // Initialize the thread for method in Producer
            Thread thread = new Thread(Producer.Produce);

            // Initialize the thread for method in Consumer
            Thread thread1 = new Thread(Consumer.Consume);

            // Starts the first thread
            thread.Start();
            // Starts the second thread
            thread1.Start();

            // To set a wait on main thread reads a key press
            Console.Read();

        }
    }
}


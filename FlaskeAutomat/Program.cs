using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FlaskeAutomat
{


    class Program
    {
        
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

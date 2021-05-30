using FlaskeAutomaten.Consumer;
using FlaskeAutomaten.Producers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    class Program
    {
        static void Main(string[] args)
        {
            BottleProducer bottleProducer = new BottleProducer();
            BottleSplitter bottleSplitter = new BottleSplitter();
            BottleConsumer bottleConsumer = new BottleConsumer();

            //Initialize a thread with a method call
            Thread producerThread = new Thread(() =>
            {
                bottleProducer.FillBuffer();

            });
            // Gives the thread a name so it can be tracked later and for easy debug
            producerThread.Name = "FillerThread";

            //Initialize another thread with another method call
            Thread sorterThread = new Thread(() =>
            {
                 bottleSplitter.SortBottles();
            });

            // Gives the thread a name so it can be tracked later and for easy debug
            sorterThread.Name = "SorterThread";

            //Initialize another thread with another method call
            Thread thread1 = new Thread(() =>
            {
                bottleConsumer.Consume();
            });


            producerThread.Start();
            //Thread.Sleep(10);
            sorterThread.Start();
            thread1.Start();

            
            
        }
    }
}

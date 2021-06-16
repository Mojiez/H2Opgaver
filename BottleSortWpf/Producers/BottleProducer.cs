using BottleSortWpf.Consumer;
using BottleSortWpf.Models;
using FlaskeAutomaten.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BottleSortWpf.Producers
{
    // This class is responsible for creation of bottle objects
    public class BottleProducer 
    {
        private int beerProducedCount = 0;
        private int sodaProducedCount = 0;
        // A stack that represent a buffer
        public static Stack<Bottle> Bottles { get; set; }
        public static bool Running { get; set; }
        // A object that works as a thread state (key object)
        public static object ProduceKey { get; set; }

        //A construktor to initialize a new stack an key object
        public BottleProducer()
        {
            // Initialize a new stack
            Bottles = new Stack<Bottle>(10);
            // Initialize a new key object
            ProduceKey = new object();
        }

        public void FillBuffer()
        {
            // Creates a instance of a bottle object
            Bottle bottle = null;
            
            while (Running)
            {
                if (Bottles.Count < 10)
                {
                    try
                    {
                        Monitor.Enter(ProduceKey);
                    }
                    catch
                    {
                        Monitor.Wait(ProduceKey);
                    }

                    if (sodaProducedCount > beerProducedCount)
                    {
                        bottle = Produce(BottleTypes.Beer);
                        beerProducedCount++;
                        Bottles.Push(bottle);
                    }
                    else
                    {
                        bottle = Produce(BottleTypes.Soda);
                        sodaProducedCount++;
                        Bottles.Push(bottle);
                    }
                    
                    // Signals the other threads 
                    Monitor.PulseAll(ProduceKey);
                    // Releases the key object
                    Monitor.Exit(ProduceKey);
                }

                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// Used to make bottle objects 
        /// </summary>
        /// <param name="bottleType"></param>
        /// <returns></returns>
        public Bottle Produce(BottleTypes bottleType)
        {
            switch (bottleType)
            {
                case BottleTypes.Beer:
                    Bottle beerBottle = new Bottle(bottleType);
                    return beerBottle;

                case BottleTypes.Soda:
                    Bottle sodaBottle = new Bottle(bottleType);
                    return sodaBottle;

                default:
                    return null;
            }
        }

    }
}

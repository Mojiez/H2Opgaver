using BottleSortWpf.Models;
using BottleSortWpf.Producers;
using FlaskeAutomaten.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BottleSortWpf.Consumer
{
    public class BottleSplitter
    {
        public static Stack<Bottle> BeerBottles { get; set; }
        public static Stack<Bottle> SodaBottles { get; set; }
        public static bool Running { get; set; }

        /// <summary>
        /// Returns a BottleSplitter with new stacks with a max size of 10 initialized through the construkter
        /// </summary>
        public BottleSplitter()
        {
            BeerBottles = new Stack<Bottle>(10);
            SodaBottles = new Stack<Bottle>(10);
        }

        /// <summary>
        /// This method is used to see if there is something in the stacks 
        /// Returns true is stack count is 1 or more false if one stack has 0
        /// </summary>
        /// <returns></returns>
        public static bool BufferControle()
        {
            if (BeerBottles.Count > 0 && SodaBottles.Count > 0)
                return true;

            else
                return false;
        }

        /// <summary>
        /// Used to sort beer and soda bottles 
        /// </summary>
        public void SortBottles()
        {
            Thread.Sleep(100);
            Bottle bottle = null;
            // Checks if the Bottle producer has any bottles in the buffer
            while (Running)
            {
                try
                {
                    Monitor.Enter(BottleProducer.ProduceKey);
                }
                catch
                {
                    Monitor.Wait(BottleProducer.ProduceKey);
                }

                if (BottleProducer.Bottles.Count > 0)
                {
                    // takes the first bottle 
                    bottle = BottleProducer.Bottles.Pop();
                }
                if (bottle != null)
                {
                    // Checks if the bottle is a beer
                    if (bottle.Type == BottleTypes.Beer && BeerBottles.Count < 10)
                    {
                        //Push the bottle to the beer bottle stack
                        BeerBottles.Push(bottle);
                    }
                    // Checks if the bottle is a soda
                    else if (bottle.Type == BottleTypes.Soda && SodaBottles.Count < 10)
                    {
                        //Push the bottle to the soda bottle stack
                        SodaBottles.Push(bottle);
                    }
                    Monitor.PulseAll(BottleProducer.ProduceKey);
                    Monitor.Exit(BottleProducer.ProduceKey);

                    
                    Thread.Sleep(450);
                }
            }
        }
    }
}

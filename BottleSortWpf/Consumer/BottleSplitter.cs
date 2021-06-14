using BottleSortWpf.Models;
using BottleSortWpf.Producers;
using FlaskeAutomaten.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BottleSortWpf.Consumer
{
    public class BottleSplitter : ISleep
    {
        public static Stack<Bottle> BeerBottles { get; set; }
        public static Stack<Bottle> SodaBottles { get; set; }

        
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
            // Checks if the Bottle producer has any bottles in the buffer
            while (BottleProducer.Bottles.Count > 1)
            {
                //Trys to grab the key object 
                if (Monitor.TryEnter(BottleProducer.ProduceKey))
                {
                    // grabs the key object
                    Monitor.Enter(BottleProducer.ProduceKey);
                    // takes the first bottle 
                    Bottle bottle = BottleProducer.Bottles.Pop();
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
                    // sleep to make the sumulation on work more realistic
                    Thread.Sleep(300);
                    Monitor.PulseAll(BottleProducer.ProduceKey);
                    Monitor.Exit(BottleProducer.ProduceKey);
                }
                else
                {
                    Sleep();
                }

                Sleep();
            }
            Sleep();
        }

        public void Sleep()
        {
            Monitor.Enter(BottleProducer.ProduceKey);
            Monitor.PulseAll(BottleProducer.ProduceKey);
            Monitor.Wait(BottleProducer.ProduceKey);
            SortBottles();
        }
    }
}

using BottleSortWpf.Models;
using BottleSortWpf.Producers;
using FlaskeAutomaten.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BottleSortWpf.Consumer
{
    public class BottleConsumer
    {
        public static Stack<Bottle> ConsumedBottles { get; set; } = new Stack<Bottle>();
        public static bool Running { get; set; }

        public void Consume()
        {
            Random random = new Random();
            while (Running)
            {
                Thread.Sleep(500);
                int ranNumber = random.Next(2);// random number 0 for beer 1 for soda
                try
                {
                    Monitor.Enter(BottleProducer.ProduceKey);
                }
                catch (Exception)
                {
                    Monitor.Wait(BottleProducer.ProduceKey);
                }


                if ((BottleTypes)ranNumber == BottleTypes.Beer && BottleSplitter.BeerBottles.Count > 0)
                {
                    ConsumedBottles.Push(BottleSplitter.BeerBottles.Pop());
                }
                else if ((BottleTypes)ranNumber == BottleTypes.Soda && BottleSplitter.SodaBottles.Count > 0)
                {
                    ConsumedBottles.Push(BottleSplitter.SodaBottles.Pop());
                }
                Monitor.PulseAll(BottleProducer.ProduceKey);
                Monitor.Exit(BottleProducer.ProduceKey);

            }
        }
    }
}

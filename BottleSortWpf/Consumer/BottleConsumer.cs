using BottleSortWpf.Models;
using BottleSortWpf.Producers;
using FlaskeAutomaten.Interfaces;
using System;
using System.Collections;
using System.Threading;

namespace BottleSortWpf.Consumer
{
    public class BottleConsumer : ISleep
    {
        public static Stack ConsumedBottles { get; set; } = new Stack();

        public void Consume()
        {
            Thread.Sleep(1000);
            Random random = new Random();

            int ranNumber = random.Next(2);// random number 0 for beer 1 for soda
            if (Monitor.TryEnter(BottleProducer.ProduceKey) && BottleSplitter.BufferControle())
            {
                Monitor.Enter(BottleProducer.ProduceKey);
                // Simulates costumers free choise
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
            else
            {
                Sleep();
            }
            Sleep();
        }

        public void Sleep()
        {
            Monitor.Enter(BottleProducer.ProduceKey);
            Monitor.PulseAll(BottleProducer.ProduceKey);
            Monitor.Wait(BottleProducer.ProduceKey);
            Thread.Sleep(1000);
            Consume();
        }
    }
}

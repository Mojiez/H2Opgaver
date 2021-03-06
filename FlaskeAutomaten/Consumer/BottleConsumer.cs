﻿using FlaskeAutomaten.Interfaces;
using FlaskeAutomaten.Models;
using FlaskeAutomaten.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomaten.Consumer
{
    public class BottleConsumer : ISleep
    {
        public void Consume()
        {
            Random random = new Random();
            int ranNumber = random.Next(2);// random number 0 for beer 1 for soda
            if(Monitor.TryEnter(BottleProducer.ProduceKey) && BottleSplitter.BufferControle())
            {
                Monitor.Enter(BottleProducer.ProduceKey);
                // Simulates costumers free choise
                if((BottleTypes)ranNumber == BottleTypes.Beer && BottleSplitter.BeerBottles.Count > 0)
                {
                    Console.WriteLine($"Consumer consumed a {BottleSplitter.BeerBottles.Pop().Id}");
                }
                else if((BottleTypes)ranNumber == BottleTypes.Soda && BottleSplitter.SodaBottles.Count > 0 )
                {
                    Console.WriteLine($"Consumer consumed a {BottleSplitter.SodaBottles.Pop().Id}");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"BeerBottles: {BottleSplitter.BeerBottles.Count} - SodaBottles: {BottleSplitter.SodaBottles.Count}");
                Console.ForegroundColor = ConsoleColor.White;
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

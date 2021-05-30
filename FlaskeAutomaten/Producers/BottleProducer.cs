using FlaskeAutomaten.Consumer;
using FlaskeAutomaten.Interfaces;
using FlaskeAutomaten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlaskeAutomaten.Producers
{
    // This class is responsible for creation of bottle objects
    public class BottleProducer : ISleep
    {
        // A stack that represent a buffer
        public static Stack<Bottle> Bottles { get; set; }
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
            // A while to secure that the method only runs under these conditions  
            // BufferControle has to return false 
            // And bottles count has to be below 10
            while (!BottleSplitter.BufferControle() && Bottles.Count < 10)
            {
                // Tests if the thread can get the key object
                if (Monitor.TryEnter(ProduceKey))
                {
                    // Trys to run the code if it catches an exeption it will write to console with the error message
                    try
                    {
                        // Thread grabs the lock(key object)
                        Monitor.Enter(ProduceKey);

                        bottle = Produce(BottleTypes.Beer);
                        Bottles.Push(bottle);
                        Console.WriteLine($"Produced: {bottle.Id}");

                        bottle = Produce(BottleTypes.Soda);
                        Bottles.Push(bottle);
                        Console.WriteLine($"Produced: {bottle.Id}");

                        Thread.Sleep(1000);

                        Console.WriteLine("Producer Done");
                        // Signals the other threads 
                        Monitor.PulseAll(ProduceKey);
                        // Releases the key object 
                        Monitor.Exit(ProduceKey);

                        Thread.Sleep(100);

                    } // Catches the error 
                    catch (Exception exception)
                    {
                        // Prints the error message
                        Console.WriteLine(exception.Message);
                    }
                    finally
                    {
                        //controle release if the code throws an error
                        Monitor.Exit(ProduceKey);
                    }
                }
                else
                {
                    Sleep();
                }
            }
            Sleep();
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
        /// <summary>
        /// This method sends the thread to wait for key object
        /// returns to FillBuffer after wait
        /// </summary>
        public void Sleep()
        {
            Monitor.Enter(ProduceKey);
            Monitor.PulseAll(ProduceKey);
            Monitor.Wait(ProduceKey);
            FillBuffer();
        }
    }
}

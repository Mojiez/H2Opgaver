using System;
using System.Collections.Generic;
using System.Threading;

namespace Dining_Philophers
{
    class Program
    {
        // Amount of philosopers created static because it has to be loaded by static methods
        private static int PHILOSOPHER_COUNT = 5;

        //The program start point
        static void Main(string[] args)
        {
            // Initialize a list of Philosopers
            var philosophers = InitializePhilosophers();
            Console.WriteLine("Dinner is starting!");
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                // Sets the thread start
                Thread philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                // Adds the thread with thread start to a list of threads
                philosopherThreads.Add(philosopherThread);
                // Starts the thread
                philosopherThread.Start();
            }

            // Sets the main thread to wait for all threads in the list with join
            foreach (var thread in philosopherThreads)
            {
                thread.Join();
            }
            Console.WriteLine("Dinner is over!");
        }

        /// <summary>
        /// This method will return a static list of Philosopers
        /// With their index so that we can tell who sits where 
        /// </summary>
        /// <returns></returns>
        private static List<Philosopher> InitializePhilosophers()
        {
            List<Philosopher> philosophers = new List<Philosopher>(PHILOSOPHER_COUNT);
            for (int i = 0; i < PHILOSOPHER_COUNT; i++)
            {
                //The construktor needs a list of philosopers, and the index number
                philosophers.Add(new Philosopher(philosophers, i));
            }

            //Add new objects(Chopsticks) to the philosopers
            foreach (var philosopher in philosophers)
            {
                philosopher.LeftChopstick = philosopher.LeftPhilosopher.RightChopstick ?? new Chopstick(); // Checks for a chopsick if null create new instance
                philosopher.RightChopstick = philosopher.RightPhilosopher.LeftChopstick ?? new Chopstick();
            }
            
            return philosophers;
        }
    }

    // this class sets the philosopers behavior
    public class Philosopher
    {
        // Sets the amount of times the philosopers eat
        private const int TIMES_TO_EAT = 5;
        // Counts the amount of times a philosoper has eaten
        private int _timesEaten = 0;
        //user by the contructor to create a readonly field
        private readonly List<Philosopher> _allPhilosophers;
        // Sets the position on the philosoper
        private readonly int _index;

        //This is the construktor for Philisoper class 
        public Philosopher(List<Philosopher> allPhilosophers, int index)
        {
            _allPhilosophers = allPhilosophers;
            _index = index;
            this.Name = string.Format("Philosopher {0}", _index);
            this.State = State.Thinking;
        }

        public string Name { get; private set; }
        public State State { get; private set; }
        public Chopstick LeftChopstick { get; set; }
        public Chopstick RightChopstick { get; set; }

        //Get the philosoper that sits to the left of selected
        public Philosopher LeftPhilosopher
        {
            get
            {
                if (_index == 0)
                    return _allPhilosophers[_allPhilosophers.Count - 1];
                else
                    return _allPhilosophers[_index - 1];
            }
        }

        //Get the philosoper that sits to the left of selected
        public Philosopher RightPhilosopher
        {
            get
            {
                if (_index == _allPhilosophers.Count - 1)
                    return _allPhilosophers[0];
                else
                    return _allPhilosophers[_index + 1];
            }
        }

        public void EatAll()
        {
            //Runs untill _timesEaten is not less than TIMES_TO_EAT
            while (_timesEaten < TIMES_TO_EAT)
            {
                //Sets the philosopers state so we can track their behavior 
                this.Think();
                if (this.PickUp())
                {
                    this.Eat();
                    this.PutDownLeft();
                    this.PutDownRight();
                }
            }
        }

        /// <summary>
        /// This method picks up the chopstik
        /// </summary>
        /// <returns></returns>
        private bool PickUp()
        {
            //The philosoper will try to take left chopstick if its not taken he will pick it up 
            if (Monitor.TryEnter(this.LeftChopstick))
            {
                Console.WriteLine(this.Name + " picks up left chopstick.");

                //The philosoper will try to take right chopstick if its not taken he will pick it up
                if (Monitor.TryEnter(this.RightChopstick))
                {
                    Console.WriteLine(this.Name + " picks up right chopstick.");
                    //Now that he has both chopsticks he can start eating
                    return true;
                }
                //If the right choptick is taken the philosoper will put down the left chopstick he took to prevent deadlock
                else
                {
                    this.PutDownLeft();
                }
            }
            
            return false;
        }
        /// <summary>
        /// Sets the state of the philosopers to eating and count timesEaten philosoper writes to console. 
        /// </summary>
        private void Eat()
        {
            this.State = State.Eating;
            _timesEaten++;
            Console.WriteLine(this.Name + " eats.");
        }

        /// <summary>
        /// Releases the lock object and writes to console 
        /// </summary>
        private void PutDownLeft()
        {
            Monitor.Exit(this.LeftChopstick);
            Console.WriteLine(this.Name + " puts down left chopstick.");
        }

        /// <summary>
        /// Releases the lock object and writes to console 
        /// </summary>
        private void PutDownRight()
        {
            Monitor.Exit(this.RightChopstick);
            Console.WriteLine(this.Name + " puts down right chopstick.");
        }

        /// <summary>
        /// Sets the philosopers state to thinking
        /// </summary>
        private void Think()
        {
            this.State = State.Thinking;
        }
    }

    //The philosoper only have two states thinking and eating
    public enum State
    {
        Thinking = 0,
        Eating = 1
    }

    // To make a chopstik object
    public class Chopstick
    {
        private static int _count = 1;
        public string Name { get; private set; }
        
        public Chopstick()
        {
            this.Name = "Chopstick " + _count++;
        }
    }
}


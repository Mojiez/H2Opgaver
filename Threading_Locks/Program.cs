using System;
using System.Threading;

namespace Threading_Locks
{
    class ScreenWriter
    {
        public object WriteLock { get; set; } = new object();
        int symbolCount = 0;
        public void WriteStars()
        {
            while (true)
            {
                WriteOnScreen('*');
            }
        }

        public void WriteHashTag()
        {
            while (true)
            {
                WriteOnScreen('#');
            }
        }

        public void WriteOnScreen(char symbol)
        {
            lock (WriteLock)
            {
                for (int i = 0; i < 60; i++)
                {
                    Console.Write(symbol);
                    symbolCount++;
                }
                Console.WriteLine(symbolCount);

            }
            Thread.Sleep(200);
        }
    }

    //Opgave 1
    class CounterProg
    {
        int counter = 0;
        object key = new object();
        
        public void MinusCount()
        {
            lock (key)
            {
                counter -= 1;
                Console.WriteLine(counter);
            }
            
            Thread.Sleep(1000);
        }

        public void AddCount()
        {
            //will lock the thread until the operation is done 
            lock (key)
            {
                // Adds 2 to counter
                counter += 2;
                Console.WriteLine(counter);
            }
            // thread will wait 1 second
            Thread.Sleep(1000);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            //Øvelse 1
            //CounterProg counterProg = new CounterProg();


            //while (true)
            //{

            //    Thread minusThread = new Thread(counterProg.MinusCount);
            //    Thread addThread = new Thread(counterProg.AddCount);
            //    addThread.Start();
            //    Thread.Sleep(10);
            //    minusThread.Start();
            //};

            
            //Øvelse 2 og 3
            ScreenWriter screenWriter = new ScreenWriter();
            Thread thread = new Thread(screenWriter.WriteStars);
            thread.Start();


            Thread thread1 = new Thread(screenWriter.WriteHashTag);
            thread1.Start();

            Console.ReadKey();
        }
    }
}

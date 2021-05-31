using System;
using System.Threading;
using Threading.ReadWrite;
using Threading.TemperatureGenerator;
using Threading.ThreadTalking;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Opgave 0-2
            ThreadTalk theProg = new ThreadTalk();
            Thread.CurrentThread.Name = "Master";

            Thread thread = new Thread(new ThreadStart(theProg.SaySomethingAboutCSharp));
            thread.Name = "Master";
            thread.Start();


            thread = new Thread(new ThreadStart(theProg.SaySomethingAboutCSharp));
            thread.Name = "Slave";
            thread.Start();

            Thread.CurrentThread.Join();
            */


            /*
            Thread newThread = new Thread(new ThreadStart(TempGenerator.GenerateNewTemperatures));
            newThread.Start();

            while (newThread.IsAlive)
            {
                
                if (TempGenerator.Changed)
                {
                        if (!TempGenerator.IsOutOfRange)
                        {
                            Console.WriteLine(TempGenerator.GeneratedTemp);
                        }
                        else
                        {
                            Console.WriteLine($"Alarm the temp is out of range\nCurrent temp: {TempGenerator.GeneratedTemp}");
                        }
                }
                Thread.Sleep(1000);
                
            }
            */

             
            Thread thread = new Thread(Reader.ReadInput);
            // starts the reader thread
            thread.Start();
            while (true)
            {
                Console.Write(Reader.InputChar);
                Thread.Sleep(10);
            }            
        }

    }
}

using System;
using System.Threading;

namespace Threading
{
    class TheProg
    {
        public void WorkThreadFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thread: {Thread.CurrentThread.Name}");
            }
        }
        public void SaySomethingAboutCSharp()
        {
            if (Thread.CurrentThread.Name == "Master")
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("C#-trådning er nemt!");
                }
            if(Thread.CurrentThread.Name == "Slave")
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Også med flere tråde...");
                }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            TheProg theProg = new TheProg();
            Thread.CurrentThread.Name = "Master";

            Thread thread = new Thread(new ThreadStart(theProg.WorkThreadFunction));
            thread.Name = "Slave";
            thread.Start();
            theProg.WorkThreadFunction();
            
           
            
            thread = new Thread(new ThreadStart(theProg.SaySomethingAboutCSharp));
            thread.Name = "Slave";
            thread.Start();

            theProg.SaySomethingAboutCSharp();

        }
    }
}

using System;
using System.Threading;

namespace Threading_Temp
{
    class Func
    {
        public int temp { get; set; }
        public void GenerateTemp()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Random random = new Random();
                Console.WriteLine($"{temp}");
                temp = random.Next(-20, 120);
                Thread.Sleep(300);

            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int alertCount = 0;
            bool running = true;
            Func func = new Func();
            Thread writer = new Thread(func.GenerateTemp);
            writer.IsBackground = true;
            writer.Name = "Writer";

            writer.Start();
            while (running)
            {
                if (func.temp > 100 || func.temp < 0)
                {
                    Thread.Sleep(100);
                    alertCount++;
                    Console.WriteLine("Alert");
                    if (alertCount == 3)
                    {
                        running = false;
                    }
                }
            }
        }
    }
}

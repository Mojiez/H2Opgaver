using System;
using System.Threading;

namespace Threading_Temp
{
    class Func
    {
        public object temp { get; set; }
        public void GenerateTemp()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Random random = new Random();
                temp = random.Next(-20, 120);
                Console.WriteLine($"{temp}");
                Thread.Sleep(2000);

            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0, alertCount = 0;
            Func func = new Func();
            Thread writer = new Thread(func.GenerateTemp);

            writer.Name = "Writer";
            writer.Start();
            while (writer.IsAlive)
            {

                input = int.Parse(func.temp.ToString());
                if (input > 100 || input < 0)
                {
                    alertCount++;
                    Console.WriteLine("Alert");
                    if (alertCount == 4)
                    {
                        writer.Abort();
                    }
                }
            }
        }
    }
}

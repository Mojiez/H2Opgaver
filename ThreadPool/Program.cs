using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            stopwatch.Start();
            ProcessWithThreadPoolMethod();

            stopwatch.Stop();
            Console.WriteLine($"Time to process Thread Pool : {stopwatch.Elapsed.ToString()}");


            stopwatch.Reset();
            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();
            Console.WriteLine($"Time to process Thread : {stopwatch.Elapsed.ToString()}");

        }
        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread thread = new Thread(Process);
                thread.Start();
            }
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

    }
}

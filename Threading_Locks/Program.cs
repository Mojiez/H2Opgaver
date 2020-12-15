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
    class Program
    {
        static void Main(string[] args)
        {
            ScreenWriter screenWriter = new ScreenWriter();
            Thread thread = new Thread(screenWriter.WriteStars);
            thread.Start();


            Thread thread1 = new Thread(screenWriter.WriteHashTag);
            thread1.Start();

            Console.ReadKey();
        }
    }
}

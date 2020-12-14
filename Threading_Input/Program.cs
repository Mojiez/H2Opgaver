using System;
using System.Threading;

namespace Threading_Input
{
    class Func
    {
        public char input { get; set; }
        public void WriteOnScreen()
        {
            input = '*';
            while (Thread.CurrentThread.IsAlive)
            {
                Console.Write(input);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Func func = new Func();
            Thread thread = new Thread(func.WriteOnScreen);
            bool running = true;

            thread.Start();
            while (running)
            {
                func.input = Console.ReadKey().KeyChar;
            }

        }
    }
}

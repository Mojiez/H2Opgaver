using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Tilfældigheder
{
    class Program
    {
        static int GetRandomInt()
        {
            Random random = new Random();
            return random.Next(100);
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                stopwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    rng.GetBytes(data);

                    int value = BitConverter.ToInt32(data, 0);
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "  ms");

            Random random = new Random();
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = random.Next(1000);
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds + "  ms");

        }
    }
}

using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

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
                    //Console.WriteLine(BitConverter.ToInt32(data, 0));
                }
            }

            Console.WriteLine(stopwatch.ElapsedTicks + "  ms");

            Random random = new Random();
            stopwatch.Reset();
            stopwatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                int randomNumber = random.Next(1000);
            }
            
            Console.WriteLine(stopwatch.ElapsedTicks + "  ms");

        }
    }
}

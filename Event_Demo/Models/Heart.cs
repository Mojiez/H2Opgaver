using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Demo.Models
{
    public class Heart
    {
        private object keyLock = new object();
        private static int maxBlood = 100;
        private static int minBlood = 30;
        private static int blood;
        public static int Blood { get => blood; set => blood = value; }
        public static bool IsAlive { get; set; }


        public Heart()
        {
            Blood = minBlood;
            IsAlive = true;
            StartHeart();
        }

        private void StartHeart()
        {
            Task.Run(async () =>
            {
                while (IsAlive)
                {
                    var inn = await PumpIn();
                    var Out = await PumpOut();
                    lock (keyLock)
                    {
                        Blood = Beat().Result;
                        Console.WriteLine("Blood: " + Blood);
                    }
                }

            });
        }

        private async Task<int> Beat()
        {
            return await Task.FromResult(1);
        }

        private async Task<bool> PumpOut()
        {
            await Task.Delay(1000);
            lock (keyLock)
            {
                blood -= 10;
            }
            return await Task.FromResult(true);
        }

        private async Task<bool> PumpIn()
        {
            await Task.Delay(1000);
            lock (keyLock)
            {
                blood += 1;
            }
            return await Task.FromResult(true);
        }

    }
}

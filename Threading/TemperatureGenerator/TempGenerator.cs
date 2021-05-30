using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading.TemperatureGenerator
{
    //This class is responsible for temperature change
    public static class TempGenerator
    {
        public static object tempLock { get; set; } = new object();
        public static int Alarms { get; set; }
        public static int GeneratedTemp { get; set; }
        public static bool IsOutOfRange { get; set; }
        public static bool Changed { get => OnChange(); set => Changed = value; } 

        private static Random random;
        private static int controlTemp;

        /// <summary>
        /// This method generates a new temperature every second 
        /// 
        /// It stops when the count is 3
        /// </summary>
        public static void GenerateNewTemperatures()
        {
            while (Alarms < 3)
            {
                //Locks the object so that no other thread can access
                lock (tempLock)
                {
                    //Generate a new random number
                    GeneratedTemp = GenerateNumber();

                    if (GeneratedTemp < 0 || GeneratedTemp > 100)
                    {
                        //Now that it is out of range. add 1 to alarm
                        Alarms++;
                        //Sets the Out of range control to true
                        IsOutOfRange = true;
                    }
                    else
                    {
                        IsOutOfRange = false;
                    }
                }
                Thread.Sleep(1000);
                controlTemp = GeneratedTemp;
            }
        }
        
        /// <summary>
        /// Returns a random number aka Temperature
        /// </summary>
        /// <returns></returns>
        private static int GenerateNumber()
        {
            random = new Random();
            return random.Next(-20, 120);
        }

        /// <summary>
        /// Returns true if GeneratedTemp has changed
        /// </summary>
        /// <returns></returns>
        public static bool OnChange()
        {
            if (GeneratedTemp == controlTemp)
                return false;
            else
                return true;
        }
    }
}

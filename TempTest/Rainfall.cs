using System;
using System.Linq;

    public  class Rainfall
    {
        public static double Mean(string town, string strng)
        {
            string towndata = strng.Split('\n').Where(x => x.Split(':')[0] == town).FirstOrDefault();
 
            if (!string.IsNullOrEmpty(towndata))
            {
                string[] temps = towndata.Split(':')[1].Split(',');
                double result = 0;
                foreach (var item in temps)
                {
                    result += Convert.ToDouble(item.Split(' ')[1]); // Add .Replace('.', ',') if culture code is DA-dk
                }
                return result / temps.Length;
            }
            else
            {
                return -1;
            }
        }
        
        private static double GetSum(double[] numbers)
        {
            double result = 0;
            
            foreach (double num in numbers)
            {
                result += num;
            }
            
            return result;
        }

        public static double Variance(string town, string strng)
        {
            string towndata = strng.Split('\n').Where(x => x.Contains(town)).FirstOrDefault();

            if (!string.IsNullOrEmpty(towndata))
            { 
                string[] temps = towndata.Split(':')[1].Split(',');
                
                double[] rainNumbers = new double[temps.Length];
                for (int i = 0; i < temps.Length; i++)
                {
                    rainNumbers[i] = Convert.ToDouble(temps[i].Split(' ')[1]); // Add .Replace('.', ',') if culture code is DA-dk
                }

                int count = rainNumbers.Length;
                double meanSum = 0, sqrtSum = 0;

                meanSum = GetSum(rainNumbers) / rainNumbers.Length;

                for (int i = 0; i < rainNumbers.Length; i++)
                {
                    sqrtSum += Math.Pow(rainNumbers[i] - meanSum, 2);
                }

                return sqrtSum / rainNumbers.Length;

            }
            else
            {
                return -1;
            }

        }

    }


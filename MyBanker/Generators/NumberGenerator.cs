using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Generators
{
    public static class NumberGenerator
    {
        public static string GenerateNumber(int prefix, int numberofDigits)
        {
            string number = "";
            if (prefix > 0)
                number = prefix.ToString();

            Random random = new Random();
            while (number.Length < numberofDigits)
            {
                number += random.Next(10);
            }

            return number;
        }

    }
}

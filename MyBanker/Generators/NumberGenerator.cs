using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Generators
{
    public static class NumberGenerator
    {
        private static int[] visaElectron = new int[] { 4026, 417500, 4508, 4844, 4913, 4917 };
        private static int[] masterCard = new int[] { 51, 52, 53, 54, 55 };
        private static int[] maestro = new int[] { 5018, 5020, 5038, 5893, 6304, 6759, 6762, 6763 };

        public static int GetPrefix(string card)
        {
            Random random = new Random();
            if (card == "VISAElectron")
                return visaElectron[random.Next(visaElectron.Length + 1)];

            else if (card == "VISA")
                return 4;

            else if (card == "MasterCard")
                return masterCard[random.Next(masterCard.Length + 1)];

            else if (card == "Maestro")
                return maestro[random.Next(maestro.Length + 1)];
            else if (card == "WidthDrawalCard")
                return 2400;

            else return 0;
        }

        public static string GenerateCardNumber(string cardType, int numberofDigits)
        {
            string number = "";
            number = GetPrefix(cardType).ToString();
            Random random = new Random();
            while (number.Length < numberofDigits)
            {
                number += random.Next(10);
            }

            return number;
        }

        public static string GenerateAccountNumber()
        {
            string accNumber = "3520";
            Random random = new Random();
            while(accNumber.Length < 14)
            {
                accNumber += random.Next(10);
            }
            return accNumber;
        }
    }
}

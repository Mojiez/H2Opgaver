using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    class Debet : Card
    {
        public Debet(string name, Type type, string accountNumber) : base(name, type, accountNumber)
        {
        }

        /// <summary>
        /// Makes sure that all information is displayed on the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Owner {CostumerName}\nCard Nr. {Number}\nAccount Nr. {AccountNumber}";
        }
    }
}

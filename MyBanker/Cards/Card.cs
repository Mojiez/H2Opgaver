using MyBanker.Accounts;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;
using MyBanker.InterFaces;

namespace MyBanker.Cards
{
    public abstract class Card
    {
        public enum Type
        {
            DebitCard,
            Maestro,
            VISAElectron,
            VISADankort,
            Mastercard
        }

        public string CostumerName { get; private set; }
        public string Number { get; private set; }
        public string AccountNumber { get; private set; }
        public Type CardType { get; set; }
        
        public Card(string name, Type cardType, string accountNumber)
        {
            CostumerName = name;
            CardType = cardType;
            AccountNumber = accountNumber;
        }

        /// <summary>
        /// Makes sure that all information is displayed on the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Owner = {CostumerName}\nCard Nr. {Number}\nAccount Nr. {AccountNumber}";
        }
    }
}

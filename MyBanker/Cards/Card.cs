using MyBanker.Accounts;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public abstract class Card
    {
        public string CustomerName { get; private set; }
        public string Number { get; private set; }
        public string AccountNumber { get; set; }

        public Card(string name, string cardType, string accountNumber)
        {
            CustomerName = name;

            if (cardType != "Maestro")
                Number = NumberGenerator.GenerateCardNumber(cardType, 16);

            else
                Number = NumberGenerator.GenerateCardNumber(cardType, 19);

            AccountNumber = accountNumber;
        }

        public override string ToString()
        {
            return $"Owner = {CustomerName}\n Card Nr. {Number}\nAccount Nr. {AccountNumber}";
        }
    }
}

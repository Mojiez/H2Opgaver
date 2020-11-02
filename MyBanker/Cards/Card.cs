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

        public Card(string name, string cardType, int numberOfDigits, string accountNumber)
        {
            CustomerName = name;
            Number = NumberGenerator.GenerateNumber(prefix: PreFixGenerator.GetPrefix(cardType), numberOfDigits);
            AccountNumber = accountNumber;
        }
    }
}

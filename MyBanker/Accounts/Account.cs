using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Accounts
{
    // This class is a bank account representation
    // Acts like a real bank account
    public class Account
    {
        public string CostumerName { get; private set; }
        public double Balance { get; private set; }
        public string Number { get; private set; }
        public List<Card> Cards { get; private set; }

        // Used to construkt a new account object
        public Account(string accountNumber, string costumerName)
        {
            Number = accountNumber;
            CostumerName = costumerName;
        }

        /// <summary>
        /// Will insert money if the account has the card selected in the parameter
        /// throws a new error if the card do not exist
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="card"></param>
        public void AddMoneyToAccountBalance(double amount, Card card)
        {
            if (Cards.Contains(card))
            {
                Balance = amount;
            }
            else
            {
                // make an costum error if the account does not have the card  
                throw new Exception("This is not your account!");
            }
        }

        /// <summary>
        /// This method is used to add a card to the given account
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToAccount(Card card)
        {
            Cards.Add(card);
        }

    }
}

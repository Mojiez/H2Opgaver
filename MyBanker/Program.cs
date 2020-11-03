using MyBanker.Accounts;
using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Dan", new DateTime(1976, 04, 25));
            Account account = new Account();

            customer.Accounts.Add(account);

            List<Card> cards = new List<Card>();

            cards.Add(CardFactory.Factory.CreateCard("VISA", customer));

            foreach (var item in cards)
            {
                Console.WriteLine(((VISA)item).ExpireDate);
                Console.WriteLine(item.ToString());
            }

        }
    }
}

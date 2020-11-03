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

            Customer customer1 = new Customer("Tim", new DateTime(2006, 05, 12));
            Account account1 = new Account();

            customer.Accounts.Add(account);
            customer1.Accounts.Add(account1);

            List<Card> cards = new List<Card>();

            cards.Add(CardFactory.Factory.CreateCard("VISA", customer));
            cards.Add(CardFactory.Factory.CreateCard("MasterCard", customer));
            cards.Add(CardFactory.Factory.CreateCard("Maestro", customer));


            cards.Add(CardFactory.Factory.CreateCard("VISAElectron", customer1));
            cards.Add(CardFactory.Factory.CreateCard("DebitCard", customer1));

            foreach (var item in cards)
            {
                if(item != null)
                Console.WriteLine(item.ToString());
            }
        }
    }
}

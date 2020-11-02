using MyBanker.Accounts;
using MyBanker.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Customers
{
    public class Customer
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        private List<Account> accounts;
        public List<Account> Accounts
        {
            get
            {
                if (accounts == null)
                    return new List<Account>();
                else
                    return accounts;
            }
            set { accounts = value; }
        }

        private List<Card> cards;
        public List<Card> Cards
        {
            get
            {
                if (cards == null)
                    return new List<Card>();
                else
                    return cards;
            }
            set { cards = value; }
        }

        public Customer(string name, DateTime birthDate)
        {
            Name = name;
            Accounts = new List<Account>();
            BirthDate = birthDate;
        }
    }
}

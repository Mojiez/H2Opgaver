using MyBanker.Accounts;
using MyBanker.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Customers
{
    public class Costumer
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Account> Accounts { get; set; }

        public Costumer(string name, DateTime birthDate)
        {
            Name = name;
            Accounts = new List<Account>();
            BirthDate = birthDate;
        }
    }
}

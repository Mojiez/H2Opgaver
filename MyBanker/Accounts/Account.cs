using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Accounts
{
    public class Account
    {
        public Customer Customer { get; set; } 
        public string Number { get; set; }
        public double AccountBalance { get; set; }

        public Account()
        {
            Number = NumberGenerator.GenerateAccountNumber();   
        }
    }
}

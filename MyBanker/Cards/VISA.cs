using MyBanker.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class VISA : Card
    {
        private int widthdrawAmount = 25000;
        private int month = DateTime.Now.Month;

        public VISA(string name, int prefix, string accountNumber) : base(name, prefix, accountNumber)
        {
            ExpireDate = DateTime.Now.AddYears(5);
        }

        public DateTime ExpireDate { get; private set; }

        public override void Deposit(int amount, Account account)
        {
            account.AccountBalance += amount;
        }

        public override int WidthDraw(int amount, Account account)
        {
            
        }
    }
}

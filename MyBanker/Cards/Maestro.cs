using MyBanker.Accounts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    class Maestro : Card, IMaestro
    {
        public DateTime ExpireDate { get; set; }
        
        public Maestro(string name, string cardType, int numberOfDigits, string accountNumber) : base(name, cardType, numberOfDigits, accountNumber)
        {
            ExpireDate = DateTime.Now.AddYears(5).AddMonths(8);
        }
    }
}

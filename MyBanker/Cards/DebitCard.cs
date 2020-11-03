using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class DebitCard : Card
    {
        public DebitCard(string name, string cardType, string accountNumber) : base(name, cardType, accountNumber)
        {
        }
    }
}

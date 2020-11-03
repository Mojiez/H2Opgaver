using MyBanker.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class MasterCard : Card, IOverDraftCard
    {
        public MasterCard(string name, string cardType, string accountNumber) : base(name, cardType, accountNumber)
        {
        }

        public void OverDraft()
        {
            throw new NotImplementedException();
        }
    }
}

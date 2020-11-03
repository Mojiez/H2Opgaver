using MyBanker.Accounts;
using MyBanker.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class VISA : Card, IOverDraftCard
    {
        public VISA(string name, string cardType, string accountNumber) : base(name, cardType, accountNumber)
        {
            ExpireDate = DateTime.Now.AddYears(5);
        }

        public DateTime ExpireDate { get; private set; }

        public void OverDraft()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Owner  {CustomerName}\nCard Nr. {Number}\nAccount Nr. {AccountNumber}\nExpireDate  {ExpireDate}";
        }
    }
}

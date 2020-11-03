using MyBanker.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class VISAElectron : VISA, ICard
    {
        public VISAElectron(string name, string cardType, string accountNumber) : base(name, cardType, accountNumber)
        {
        }

        public void InternationalUse()
        {
            throw new NotImplementedException();
        }

        public void InternetUse()
        {
            throw new NotImplementedException();
        }
    }
}

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
        /// <summary>
        /// Makes the card usefull international
        /// </summary>
        public void InternationalUse()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Makes the card usefull on the internet
        /// </summary>
        public void InternetUse()
        {
            throw new NotImplementedException();
        }
    }
}

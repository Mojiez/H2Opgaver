using MyBanker.Accounts;
using MyBanker.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class Maestro : Card, ICard
    {
        public DateTime ExpireDate { get; set; }

        public Maestro(string name, string cardType, string accountNumber) : base(name, cardType, accountNumber)
        {
            ExpireDate = DateTime.Now.AddYears(5).AddMonths(8);
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

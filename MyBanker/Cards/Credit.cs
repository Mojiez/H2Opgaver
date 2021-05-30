using MyBanker.Accounts;
using MyBanker.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class Credit : Card
    {
        public DateTime ExpireDate;
        public Credit(string name, Type type, string accountNumber, DateTime expireDate) : base(name, type, accountNumber)
        {
            ExpireDate = expireDate;
        }

        /// <summary>
        /// Makes sure that all information is displayed on the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Owner {CostumerName}\nCard Nr. {Number}\nAccount Nr. {AccountNumber}\nExpireDate {ExpireDate}";
        }
    }
}

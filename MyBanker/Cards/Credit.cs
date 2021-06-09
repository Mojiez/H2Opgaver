using System;

namespace MyBanker.Cards
{
    public class Credit : Card
    {
        // Property to hold the expire date on the card
        public DateTime ExpireDate { get; set; }
        
        /// <summary>
        /// This is the construktor for this class
        /// This class only has one property
        /// Inherites all other properties from its super class Card
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="accountNumber"></param>
        /// <param name="expireDate"></param>
        /// <param name="number"></param>
        public Credit(string name, Type type, string accountNumber, DateTime expireDate, string number) : base(name, type, accountNumber, number)
        {
            ExpireDate = expireDate;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nEpire Date: {ExpireDate.ToString("mm/dd/yyyy")}";
        }
    }
}

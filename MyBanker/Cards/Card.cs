using MyBanker.Accounts;
using System;

namespace MyBanker.Cards
{
    /// <summary>
    /// This class represent the highest abstraction level of a bank card
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// This enum is used to set a type on the card
        /// </summary>
        public enum Type
        {
            DebitCard,
            Maestro,
            VISAElectron,
            VISADankort,
            Mastercard
        }
        //This is a property made for costumer name
        public string CostumerName { get; private set; }
        //This is a property made for card number
        public string Number { get; private set; }
        //This is a property made for account number 
        public string AccountNumber { get; private set; }
        //This is a property made for defining the card type 
        public Type CardType { get; private set; }

        /// <summary>
        /// The Card construktor to make a new instance of the object Card
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cardType"></param>
        /// <param name="accountNumber"></param>
        /// <param name="number"></param>
        public Card(string name, Type cardType, string accountNumber, string number)
        {
            CostumerName = name;
            CardType = cardType;
            AccountNumber = accountNumber;
            Number = number;
        }

        /// <summary>
        /// Overrides the base method ToString to make it show the properties for this class
        /// Makes sure that all information is displayed on the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Card type: {CardType}\nOwner = {CostumerName}\nCard Nr. {Number}\nAccount Nr. {AccountNumber}";
        }
    }
}

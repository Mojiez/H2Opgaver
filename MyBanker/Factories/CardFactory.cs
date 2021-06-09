using MyBanker.Cards;
using MyBanker.Generators;
using System;

namespace MyBanker.Factories
{
    public class CardFactory
    {
        //Controle object to make a lock
        private static object controle = new object();
        // Make a static instance of factory for singleton
        private static CardFactory _factory = null;
        // this is a singleton used for thread securety so only one instance of this class can be instantiated at a time
        public static CardFactory Factory
        {
            get
            {
                // the lock object used by the thread to block other threads from entering
                lock (controle)
                {
                    // Null check return a new instance if null else return same 
                    if (_factory == null)
                    {
                        _factory = new CardFactory();
                        return _factory;
                    }
                    else
                    {
                        // Returns the first generated instance of _factory
                        return _factory;
                    }
                }
            }
        }
        
        /// <summary>
        /// Takes the costumer name to set the proper
        /// </summary>
        /// <param name="costumerName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Card GenerateDebitCard(string costumerName, Card.Type type)
        {
            return new Debet(costumerName, type, NumberGenerator.GenerateAccountNumber(), NumberGenerator.GenerateCardNumber(type, 16));
        }

        /// <summary>
        /// Generates a credit card based on the card type
        /// </summary>
        /// <param name="costumerName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Card GenerateVisaCard(string costumerName, Card.Type type)
        {
            if (type == Card.Type.Maestro)
                return new Credit(costumerName, type, NumberGenerator.GenerateAccountNumber(), DateTime.Now.AddYears(5).AddMonths(8), NumberGenerator.GenerateCardNumber(type, 19));

            else
                return new Credit(costumerName, type, NumberGenerator.GenerateAccountNumber(), DateTime.Now.AddYears(5), NumberGenerator.GenerateCardNumber(type, 16));
        }
    }
}

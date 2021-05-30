using MyBanker.Accounts;
using MyBanker.Cards;
using MyBanker.Customers;
using MyBanker.Generators;
using System;
using System.Collections.Generic;
using System.Text;
using static MyBanker.Cards.Card;

namespace MyBanker
{
    public class CardFactory
    {
        private static object controle = new object();
        private static CardFactory _factory = null;
        public static CardFactory Factory
        {
            get
            {
                lock (controle)
                {
                    if (_factory == null)
                    {
                        _factory = new CardFactory();
                        return _factory;
                    }
                    else
                    {
                        return _factory;
                    }
                }
            }
        }
     
        public Card GenerateDebitCard(string costumerName, Card.Type type)
        {
            return new Debet(costumerName, type, NumberGenerator.GenerateCardNumber(type, 16));
        }

        public Card GenerateVisaCard(string costumerName, Card.Type type)
        {
            if (type == Card.Type.Maestro)
                return new Credit(costumerName, type, NumberGenerator.GenerateCardNumber(type, 19), DateTime.Now.AddYears(5).AddMonths(8));

            else
                return new Credit(costumerName, type, NumberGenerator.GenerateCardNumber(type, 16), DateTime.Now.AddYears(5));
        }

    }
}

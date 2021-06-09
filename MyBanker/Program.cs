using MyBanker.Cards;
using MyBanker.Factories;
using System;
using System.Collections.Generic;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>()
            {
                //Calls the card factory to generate the card object
                CardFactory.Factory.GenerateDebitCard("Ninna", Card.Type.DebitCard),
                CardFactory.Factory.GenerateVisaCard("Torben", Card.Type.Maestro),
                CardFactory.Factory.GenerateVisaCard("Mathias", Card.Type.Mastercard),
                CardFactory.Factory.GenerateVisaCard("Morten", Card.Type.VISADankort),
                CardFactory.Factory.GenerateVisaCard("Tina", Card.Type.VISAElectron),
            };

            
            foreach (var item in cards)
            {
                if(item != null)
                Console.WriteLine(item.ToString());
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
            }
        }
    }
}

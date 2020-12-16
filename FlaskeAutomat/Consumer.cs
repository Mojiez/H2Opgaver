using System;

namespace FlaskeAutomat
{
    class Consumer
    {
        public Bottle Bottle;
        public string TypeOfDrink;

        public void BuyABottle(object itemLock)
        {
            lock (itemLock)
            {
                if (TypeOfDrink == "Soda")
                {
                    Bottle = Splitter.sodaBottles.Dequeue();
                    Console.WriteLine("Consumer grabed Soda");
                }
                else
                {
                    Bottle = Splitter.beerBottles.Dequeue();
                    Console.WriteLine("Consumer grabed Beer");
                }
            }
        }
    }
}

using System;

namespace TestAsyncProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Bottle[] bottles = new Bottle[] { 
                null,
                new Bottle(BottleTypes.Beer), 
                new Bottle(BottleTypes.Beer),
                new Bottle(BottleTypes.Beer), 
                new Bottle(BottleTypes.Beer),
                new Bottle(BottleTypes.Soda), 
                new Bottle(BottleTypes.Soda),
                new Bottle(BottleTypes.Soda),
                new Bottle(BottleTypes.Soda),
                new Bottle(BottleTypes.Soda) 
            };

            



            foreach (var item in bottles)
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}

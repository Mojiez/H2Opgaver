using System;

namespace TestAsyncProducer
{
    public class Bottle
    {
        public BottleTypes Type { get; set; }
        public string Id { get; private set; }
        /// <summary>
        /// Returns a bottle object
        /// Generates a random number for id
        /// </summary>
        /// <param name="bottleType"></param>
        public Bottle(BottleTypes bottleType)
        {
            Random random = new Random();

            Type = bottleType;
            Id = $"{bottleType}-{random.Next(100, 99999)}";
        }
    }
}

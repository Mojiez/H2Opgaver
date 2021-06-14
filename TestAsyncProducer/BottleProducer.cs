using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsyncProducer.Producers
{
    // This class is responsible for creation of bottle objects
    public class BottleProducer 
    {
        public Stack<Bottle> Bottles { get; set; }
        public BottleProducer()
        {
            Bottles = new Stack<Bottle>(10);
        }

        private async void MakeBottle()
        {
            Bottle bottle = Produce();
           Bottles.Push();
        }

        private Bottle Produce()
        {
            new Thread(() => 
            {
            
            });

        }

    }
}

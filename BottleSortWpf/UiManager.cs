using BottleSortWpf.Consumer;
using BottleSortWpf.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BottleSortWpf
{
    // Responsible for communication between ui an logic
    public class UiManager
    {
        private BottleProducer producer;
        private BottleSplitter splitter;
        private BottleConsumer consumer;
        private Window window;

        public UiManager(Window window)
        {
            producer = new BottleProducer();
            splitter = new BottleSplitter();
            consumer = new BottleConsumer();
            this.window = window;
        }
        public int ProducerCount { get; set; }
        public int BeerCount { get; set; }
        public int SodaCount { get; set; }

        private void Update()
        {
            Thread.Sleep(100);
            //Dispatcher.InvokeAsync(() =>
            //{
            //    Duration duration = new Duration(TimeSpan.FromMilliseconds(10));
            //    DoubleAnimation animation = new DoubleAnimation(BottleProducer.Bottles.Count * 10, duration);
            //    window.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation);
            //    window.producerText.Text = Convert.ToString(BottleProducer.Bottles.Count);
            //});
            Update();
        }



        public void StartProducer()
        {
            Dispatcher.CurrentDispatcher.Invoke(() => 
            {
                producer.FillBuffer();
            });
        }

        public void StartSplitter()
        {

        }

        public void StarConsumer()
        {

        }
    }
}

using BottleSortWpf.Consumer;
using BottleSortWpf.ImagesControle;
using BottleSortWpf.Producers;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace BottleSortWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImagesManager imagesManager = new ImagesManager();

        BottleProducer producer = new BottleProducer();
        BottleConsumer consumer = new BottleConsumer();
        BottleSplitter splitter = new BottleSplitter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Update()
        {
            UpdateProducer();
        }

        private void UpdateProducer()
        {
            Thread.Sleep(100);
            Dispatcher.Invoke(() =>
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(1));
                DoubleAnimation animation = new DoubleAnimation(BottleProducer.Bottles.Count * 10, duration);
                this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation);
                this.producerText.Text = Convert.ToString(BottleProducer.Bottles.Count);
            });
            UpdateSplitter();
        }

        private void UpdateSplitter()
        {
            Thread.Sleep(100);
            Dispatcher.Invoke(() =>
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(1));
                DoubleAnimation animation = new DoubleAnimation(BottleSplitter.BeerBottles.Count * 10, duration);
                this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation);
                this.splitterBeer.Text = Convert.ToString(BottleSplitter.BeerBottles.Count);

                Duration duration1 = new Duration(TimeSpan.FromMilliseconds(1));
                DoubleAnimation animation1 = new DoubleAnimation(BottleSplitter.SodaBottles.Count * 10, duration1);
                this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation1);
                this.splitterSoda.Text = Convert.ToString(BottleSplitter.SodaBottles.Count);
            });
            UpdateConsumer();
        }

        private void UpdateConsumer()
        {
            Thread.Sleep(100);
            Dispatcher.Invoke(() =>
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(1));
                DoubleAnimation animation = new DoubleAnimation(BottleConsumer.ConsumedBottles.Count, duration);
                this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation);
                this.consumedBottles.Text = Convert.ToString(BottleConsumer.ConsumedBottles.Count);
            });
            Update();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                new Thread(() =>
                {
                    producer.FillBuffer();
                    producer.Running = true;
                }).Start();

                new Thread(() =>
                {
                    splitter.SortBottles();
                    splitter.Running = true;
                }).Start();

                new Thread(() => 
                {
                    consumer.Consume();
                }).Start();
            });
            
            this.Dispatcher.Invoke(() =>
            {
                new Thread(() =>
                {
                    Update();
                }).Start();
            });
        }
    }
}

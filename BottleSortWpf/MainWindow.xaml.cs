using BottleSortWpf.Animation;
using BottleSortWpf.Consumer;
using BottleSortWpf.Producers;
using System;
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

        Animator animator = new Animator();
        BottleProducer producer = new BottleProducer();
        BottleConsumer consumer = new BottleConsumer();
        BottleSplitter splitter = new BottleSplitter();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method runs with 3 other methods to create a method chain or a loop
        /// Updates the ui
        /// </summary>
        private void Update()
        {
            Thread.Sleep(20);
            UpdateProducer();
        }

        /// <summary>
        /// This method runs with 3 other methods to create a method chain or a loop
        /// Updates the ui
        /// </summary>
        private void UpdateProducer()
        {
            while (BottleProducer.Running)
            {
                // Calls the ui thread or main thread
                this.Dispatcher.Invoke(() =>
                {
                    // Sets the ProgressBar Value to trigger a On changed event 
                    this.producerBar.Value = BottleProducer.Bottles.Count * 10;
                });

                
                UpdateSplitter();
            }
        }

        /// <summary>
        /// This method runs with 3 other methods to create a method chain or a loop
        /// Updates the ui
        /// </summary>
        private void UpdateSplitter()
        {
            while (BottleSplitter.Running)
            {
                // Calls the ui thread or main thread
                this.Dispatcher.Invoke(() =>
                {
                    // Sets the ProgressBar Value to trigger a On changed event
                    this.splitterBarBeer.Value = BottleSplitter.BeerBottles.Count * 10;
                    this.splitterBarSoda.Value = BottleSplitter.SodaBottles.Count * 10;
                });

                
                UpdateConsumer();
            }
        }

        /// <summary>
        /// This method runs with 3 other methods to create a method chain or a loop
        /// Updates the ui
        /// </summary>
        private void UpdateConsumer()
        {
            while (BottleConsumer.Running)
            {
                // Calls the ui thread aka main thread to set set value
                Dispatcher.Invoke(() =>
                {
                    // sets the value on the ui
                    this.consumerBar.Value = BottleConsumer.ConsumedBottles.Count;
                });
                Thread.Sleep(10);
                Update();
            }
        }

        /// <summary>
        /// This method triggers from the front end On Button press
        /// Starts the logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var thread = Thread.CurrentThread.Name;
            new Thread(() =>
            {
                BottleProducer.Running = true;
                producer.FillBuffer();
            }).Start();

            new Thread(() =>
            {
                BottleSplitter.Running = true;
                splitter.SortBottles();
            }).Start();

            new Thread(() =>
            {
                BottleConsumer.Running = true;
                consumer.Consume();
            }).Start();

            new Thread(() =>
            {
                Update();
            }).Start();
        }

        /// <summary>
        /// This method triggers from the front end On Button press
        /// Stops the logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            BottleProducer.Running = false;
            BottleSplitter.Running = false;
            BottleConsumer.Running = false;
        }

        /// <summary>
        /// /// This method uses the Ui thread therefor no need for the Dispatcher
        /// This method runs on a valueChanged event
        /// Runs if the producerBar value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void producerBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animator.GetAnimation());
            this.producerText.Text = Convert.ToString(BottleProducer.Bottles.Count);
            if (BottleProducer.Bottles.Count != 0)
            {
                this.producerItem.Text = "Produced: " + BottleProducer.Bottles.Peek().Type;
            }
        }

        /// <summary>
        /// /// This method uses the Ui thread therefor no need for the Dispatcher
        /// This method runs on a valueChanged event
        /// Runs if the splitterBarBeer value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterBarBeer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.splitterBarBeer.BeginAnimation(ProgressBar.ValueProperty, animator.GetAnimation());
            this.splitterBeer.Text = "Beer: " + Convert.ToString(BottleSplitter.BeerBottles.Count);
        }

        /// <summary>
        /// /// This method uses the Ui thread therefor no need for the Dispatcher
        /// This method runs on a valueChanged event
        /// Runs if the splitterBarSoda value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitterBarSoda_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.splitterBarSoda.BeginAnimation(ProgressBar.ValueProperty, animator.GetAnimation());
            this.splitterSoda.Text = "Soda: " + Convert.ToString(BottleSplitter.SodaBottles.Count);
        }

        /// <summary>
        /// This method uses the Ui thread therefor no need for the Dispatcher
        /// This method runs on a valueChanged event
        /// Runs if the consumerBar value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consumerBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.consumerBar.BeginAnimation(ProgressBar.ValueProperty, animator.GetAnimation());
            this.consumedBottles.Text = Convert.ToString(BottleConsumer.ConsumedBottles.Count);
            this.bottleConsumed.Text = $"Beer Consumed: " + consumer.BeerCount + $" Soda Consumed: " + consumer.SodaCount;
        }
    }
}
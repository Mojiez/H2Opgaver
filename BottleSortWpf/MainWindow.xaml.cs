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
            Thread.Sleep(100);
            Dispatcher.InvokeAsync(() =>
            {
                Duration duration = new Duration(TimeSpan.FromMilliseconds(10));
                DoubleAnimation animation = new DoubleAnimation(BottleProducer.Bottles.Count * 10, duration);
                this.producerBar.BeginAnimation(ProgressBar.ValueProperty, animation);
                this.producerText.Text = Convert.ToString(BottleProducer.Bottles.Count);
            });

            Update();
        }
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                new Thread(() =>
                {
                    producer.FillBuffer();
                }).Start();

            });
            Dispatcher.Invoke(() =>
            {
                new Thread(() =>
                {
                    Update();
                }).Start();
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressBarTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int value;
        public MainWindow()
        {
            InitializeComponent();
            this.testValue.Text = value.ToString();
        }

        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DoubleAnimation animation = new DoubleAnimation(value, new Duration(TimeSpan.FromSeconds(1)));
            Dispatcher.Invoke(() =>
            {
                
                progress.BeginAnimation(ProgressBar.ValueProperty, animation);
                
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                this.progress.Value++;
                value++;
                this.testValue.Text = value.ToString();
            });
        }
    }
}

using BagageSorting_App.UiControle;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BagageSorting_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CanvasAnimator animation;
        public MainWindow()
        {
            InitializeComponent();
            animation = new CanvasAnimator();
            window.Children.Add(animation.SetUpAirPortCanvas());
            Thread.Sleep(10);
            animation.MovePix();

        }
    }
}
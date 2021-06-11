using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BagageSorting_App.UiControle
{
    public class CanvasAnimator
    {
        public List<Canvas> canvas = new List<Canvas>();
        public Canvas SetUpAirPortCanvas()
        {
            Canvas mainCanvas = new Canvas();
            mainCanvas.Background = Brushes.Black;
            mainCanvas.Width = 500;
            mainCanvas.Height = 500;
            Canvas canvas1 = new Canvas()
            {
                Background = Brushes.White,
                Width = 10,
                Height = 10,

            };
            Canvas.SetLeft(canvas1, 1);
            Canvas.SetTop(canvas1, 2);
            Canvas.SetBottom(canvas1, 0);
            Canvas.SetRight(canvas1, 0);

            Canvas canvas2 = new Canvas()
            {
                Background = Brushes.Red,
                Width = 10,
                Height = 10
            };

            Canvas.SetLeft(canvas2, 1);
            Canvas.SetTop(canvas2, 3);
            Canvas.SetBottom(canvas2, 0);
            Canvas.SetRight(canvas2, 0);

            Canvas canvas3 = new Canvas()
            {
                Background = Brushes.White,
                Width = 10,
                Height = 10
            };
            Canvas.SetLeft(canvas3, 1);
            Canvas.SetTop(canvas3, 4);
            Canvas.SetBottom(canvas3, 0);
            Canvas.SetRight(canvas3, 0);

            Canvas canvas4 = new Canvas()
            {
                Background = Brushes.Red,
                Width = 10,
                Height = 10,

            };
            Canvas.SetLeft(canvas4, 1);
            Canvas.SetTop(canvas4, 5);
            Canvas.SetBottom(canvas4, 0);
            Canvas.SetRight(canvas4, 0);

            mainCanvas.Children.Add(canvas1);
            mainCanvas.Children.Add(canvas2);
            mainCanvas.Children.Add(canvas3);
            mainCanvas.Children.Add(canvas4);

            canvas.Add(canvas1);
            canvas.Add(canvas2);
            canvas.Add(canvas3);
            canvas.Add(canvas4);
            return mainCanvas;
        }

        public void MovePix()
        {
            Random random = new Random();
            Canvas.SetTop(canvas[0], random.Next(10));
        }
    }
}

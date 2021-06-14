using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BottleSortWpf.ImagesControle
{
    public class ImagesManager
    {
        private string[] picturePaths = new string[]
        {
            @"C:\Users\kenn229k\Desktop\Picture\FlaskeAutomat\Bottle2.png",
            @"C:\Users\kenn229k\Desktop\Picture\FlaskeAutomat\SmashedBottle.jpg",
            @"C:\Users\kenn229k\Desktop\Picture\FlaskeAutomat\BeerBottle.jpg"
        };

        public Image GetSodaPicture()
        {
            Image image = new Image();
            image.Width = 200;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(picturePaths[0]);
            bitmap.DecodePixelWidth = 200;
            bitmap.EndInit();

            image.Source = bitmap;
            return image;
        }

        public Image GetSmashedSodaPicture()
        {
            Image image = new Image();
            image.Width = 200;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(picturePaths[1]);
            bitmap.DecodePixelWidth = 200;
            bitmap.EndInit();

            image.Source = bitmap;
            return image;
        }

        public Image GetBeerPicture()
        {
            Image image = new Image();
            image.Width = 200;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(picturePaths[2]);
            bitmap.DecodePixelHeight = 100;
            bitmap.EndInit();

            image.Source = bitmap;
            return image;
        }

    }
}

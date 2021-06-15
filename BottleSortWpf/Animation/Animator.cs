using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BottleSortWpf.Animation
{
    public class Animator
    {
        private DoubleAnimation Animation { get; set; }

        public void SetAnimation(int fromValue = 0, int toValue = 10)
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(1000));
            Animation = new DoubleAnimation(fromValue, toValue, duration);
        }

        public DoubleAnimation GetAnimation()
        {
            return Animation;
        }
    }
}

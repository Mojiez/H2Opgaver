﻿using System;
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

        public DoubleAnimation GetAnimation()
        {
            return Animation;
        }
    }
}

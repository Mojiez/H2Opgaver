﻿using BirdsFlyingAround_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsFlyingAround_App.Date_Classes
{
    // This class represents a pinguin 
    // A duck is a bird therefore it inherites from bird
    // Not all birds can fly that why we have the interface IFly
    // A pinguin cant fly, so pinguin cant implement IFly because it breaks l from solid
    // The object needs to act like what defines it
    public class Pinguin : Bird
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public override void Shit()
        {
            throw new NotImplementedException();
        }

        public override void Sing()
        {
            throw new NotImplementedException();
        }
    }
}

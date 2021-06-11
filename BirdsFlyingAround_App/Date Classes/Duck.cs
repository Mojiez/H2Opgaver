using BirdsFlyingAround_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsFlyingAround_App.Date_Classes
{
    // This class represents a duck 
    // A duck is a bird therefore it inherites from bird
    // Not all birds can fly that why we have the interface IFly
    // A duck can fly therefore it has to implement IFly to get the fly method 
    public class Duck : Bird, IFly
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
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

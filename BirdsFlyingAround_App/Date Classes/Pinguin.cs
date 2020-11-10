using BirdsFlyingAround_App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdsFlyingAround_App.Date_Classes
{
    class Pinguin : Bird, IAltitude
    {
        public override void Draw()
        {
            //Draw the bird on screen
        }

        public void SetAltitude(double longitude, double latitude)
        {
            //sets the hight on the bird aka flying
        }

        public override void SetLocation(double longitude, double latitude)
        {
            //sets the location on the bird
        }
    }
}

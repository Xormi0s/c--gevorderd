using System;
using System.Collections.Generic;
using System.Text;

namespace Les3Oefening
{
    class Square: Shape
    {
        private double sideLength;

        public double SideLength
        {
            get { return sideLength; }
            set { sideLength = value; }
        }

        public override double GetSurface()
        {
            return (sideLength * sideLength);
        }

        public override double GetCircumference()
        {
            return (sideLength * 4);
        }

        public override string ToString()
        {
            return "Vierkant omtrek: " + this.GetCircumference() + " / Oppervlakte: " + this.GetSurface() + base.ToString();
        }
    }
}

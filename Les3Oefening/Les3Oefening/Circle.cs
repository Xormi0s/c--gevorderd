using System;
using System.Collections.Generic;
using System.Text;

namespace Les3Oefening
{
    class Circle: Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public override double GetSurface()
        {
            return (radius * radius * Math.PI);
        }

        public override double GetCircumference()
        {
            return (2 * radius * Math.PI);
        }

        public override string ToString()
        {
            return "Cirkel omtrek: " +this.GetCircumference() + " / Oppervlakte: " + this.GetSurface() + base.ToString();
        }
    }
}

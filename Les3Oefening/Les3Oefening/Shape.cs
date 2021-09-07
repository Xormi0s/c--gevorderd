using System;
using System.Collections.Generic;
using System.Text;

namespace Les3Oefening
{
    abstract class Shape: IColorObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public abstract double GetSurface();

        public abstract double GetCircumference();

        public ColorTypes ColorType { get; set; }

        public int ColorDepth { get; set; }

        public override string ToString()
        {
            return " / Naam: " + this.name + " / Kleur type: " + this.ColorType.ToString() + " / Kleur diepte: " + this.ColorDepth;
        }
    }
}

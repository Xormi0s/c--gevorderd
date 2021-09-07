using System;
using System.Collections.Generic;
using System.Text;

namespace Les3Oefening
{
    class Picture: IColorObject
    {
        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public ColorTypes ColorType { get; set; }
        public int ColorDepth { get; set; }

        public override string ToString()
        {
            return "Foto locatie: " + this.location + " / Kleur type: " + this.ColorType.ToString() + " / Kleur diepte: " + this.ColorDepth;
        }
    }
}

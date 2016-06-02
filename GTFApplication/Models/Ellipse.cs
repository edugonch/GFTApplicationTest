using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    class Ellipse : Shape
    {
        public Ellipse(float x, float y, float radiusMin, float radiusMax)
            : base(x, y, new float[] { radiusMin, radiusMax })
        {

        }

        public float RadiusMin
        {
            get
            {
                return Sides[0];
            }
        }

        public float RadiusMax
        {
            get
            {
                return Sides[1];
            }
        }

        public override string ToString()
        {
            return String.Format("shape {0}: ellipse with center at ({1}, {2}) and radius min {3}, radius max {4}",
                Id, X, Y, RadiusMin, RadiusMax);
        }

        public override bool ContainPoint(float x, float y)
        {
            if (x >= this.X && x <= this.RadiusMax)
            {
                if (y >= this.Y && y <= this.RadiusMin)
                    return true;
            }
            if (x <= this.X && x >= this.RadiusMax)
            {
                if (y <= this.Y && y >= this.RadiusMin)
                    return true;
            }
            return false;
        }

        public override double Area
        {
            get
            {
                if (this.area <= 0.0)
                {
                    this.area = Math.PI * this.RadiusMin * this.RadiusMax;
                }

                return this.area;
            }
        }
    }
}

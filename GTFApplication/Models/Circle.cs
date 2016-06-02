using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public class Circle : Shape
    {
        
        public Circle(float x, float y, float radius)
            : base(x, y, new float[] { radius })
        {

        }

        public float Radius
        {
            get
            {
                return Sides[0];
            }
        }

        public override string ToString()
        {
            return String.Format("shape {0}: circle with center at ({1}, {2}) and radius {3}",
                Id, X, Y, Radius);
        }

        public override bool ContainPoint(float x, float y)
        {
            double squareDsit = Math.Pow((this.X - x), 2) + Math.Pow((this.Y - y), 2);
            return squareDsit <= Math.Pow(this.Radius, 2);
        }

        public override double Area
        {
            get
            {
                if(this.area <= 0.0)
                {
                    this.area = Math.PI * Math.Pow(this.Radius, 2);
                }

                return this.area;
            }
        }
    }
}

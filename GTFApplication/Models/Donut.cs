using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public class Donut : Shape
    {
        public Donut(float x, float y, float radius1, float radius2)
            : base(x, y, new float[] { radius1, radius2})
        {

        }

        public float Radius1
        {
            get
            {
                return Sides[0];
            }
        }

        public float Radius2
        {
            get
            {
                return Sides[1];
            }
        }

        public override string ToString()
        {
            return String.Format("shape {0}: donut with center at ({1}, {2}) and radius1 {3}, radius2 {4}",
                Id, X, Y, Radius1, Radius2);
        }

        public override bool ContainPoint(float x, float y)
        {
            double squareDsit = Math.Pow((this.X - x), 2) + Math.Pow((this.Y - y), 2);
       
            return (Math.Pow(this.Radius2, 2) >= squareDsit && squareDsit <= Math.Pow(this.Radius1, 2));
        }

        public override double Area
        {
            get
            {
                if (this.area <= 0.0)
                {
                    var area1 = Math.PI * Math.Pow(this.Radius1, 2);

                    var area2 = Math.PI * Math.Pow(this.Radius2, 2);

                    this.area = area1 - area2;
                }

                return this.area;
            }
        }
    }
}

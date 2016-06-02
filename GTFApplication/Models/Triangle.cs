using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public class Triangle : Shape
    {
        public Triangle(float x_vertice1, float y_vertice1, float x_vertice2, float y_vertice2, float x_vertice3, float y_vertice3)
            : base(0, 0, new float[] { x_vertice1, y_vertice1, x_vertice2, y_vertice2, x_vertice3, y_vertice3 })
        {

        }

        public float X1
        {
            get
            {
                return Sides[0];
            }
        }

        public float Y1
        {
            get
            {
                return Sides[1];
            }
        }

        public float X2
        {
            get
            {
                return Sides[2];
            }
        }

        public float Y2
        {
            get
            {
                return Sides[3];
            }
        }

        public float X3
        {
            get
            {
                return Sides[4];
            }
        }

        public float Y3
        {
            get
            {
                return Sides[5];
            }
        }


        public override double Area
        {
            get
            {
                if (this.area <= 0.0)
                {
                    this.area = Math.Abs((this.X1 * (this.Y2 - this.Y3) + this.X2 * (this.Y3 - this.Y1) + this.X3 * (this.Y1 - this.Y2)) / 2);
                }

                return this.area;
            }
        }

        public override bool ContainPoint(float x, float y)
        {
            var s = this.Y1 * this.X3 - this.X1 * this.Y3 + (this.Y3 - this.Y1) * x + (this.X1 - this.X2) * y;

            var t = this.X1 * this.Y2 - this.Y1 * this.X2 + (this.Y1 - this.Y2) * x + (this.X2 - this.X1) * y;

            if ((s < 0) != (t < 0))
                return false;

            var A = -this.Y2 * this.X2 + this.Y1 * (this.X3 - this.X1) + this.X1 * (this.Y2 - this.Y3) + this.X1 * this.Y3;

            if (A < 0.0)
            {
                s = -s;
                t = -t;
                A = -A;
            }
            return s > 0 && t > 0 && (s + t) <= A;
        }


        public override string ToString()
        {
            return String.Format("shape {0}: triangle with coordinates at ({1} {2}, {3} {4}, {5} {6})",
                Id, X1, Y1, X2, Y2, X3, Y3);
        }
    }
}

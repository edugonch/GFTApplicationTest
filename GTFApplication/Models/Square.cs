using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public class Square : Shape
    {
        public Square(float x, float y, float side)
            : base(x, y, new float[] { side })
        {

        }

        public float Side
        {
            get
            {
                return Sides[0];
            }
        }

        public override string ToString()
        {
            return String.Format("shape {0}: square with center at ({1}, {2}) and side {3}",
                Id, X, Y, Side);
        }

        public override double Area
        {
            get
            {
                if (this.area <= 0.0)
                {
                    this.area = Math.Pow(this.Side, 2);
                }

                return this.area;
            }
        }

        public override bool ContainPoint(float x, float y)
        {

            //Top Right Corner
            float top_right_x = this.X + this.Side;
            float top_right_y = this.Y + this.Side;


            if (x < this.X || x > top_right_x || y < this.Y || y > top_right_y)
            {
                return false;
            }

            return true;
        }
    }
}

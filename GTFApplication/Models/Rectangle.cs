using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public class Rectangle : Shape
    {
        public Rectangle(float x, float y, float side1, float side2)
            : base(x, y, new float[] { side1, side2 })
        {

        }

        public float Side1
        {
            get
            {
                return Sides[0];
            }
        }

        public float Side2
        {
            get
            {
                return Sides[1];
            }
        }

        public override string ToString()
        {
            return String.Format("shape {0}: rectangle with center at ({1}, {2}) and side1 {3}, side2 {4}",
                Id, X, Y, Side1, Side2);
        }

        public override double Area
        {
            get
            {
                if (this.area <= 0.0)
                {
                    this.area = this.Side1 * this.Side2;
                }

                return this.area;
            }
        }

        public override bool ContainPoint(float x, float y)
        {
            // Assuming the corner of the rectangle is the left bottom corner
            // Assuming the side 1 goes to left bottom to left top
            // Assuming the side 2 goes to left bottom to right bottom


            //Top Right Corner
            float top_right_x = this.X + this.Side2;
            float top_right_y = this.Y + this.Side1;


            if(x < this.X || x > top_right_x || y < this.Y || y > top_right_y)
            {
                return false;
            }

            return true;
        }
    }
}

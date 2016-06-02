using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Models
{
    public abstract class Shape
    {
        protected double area;
        public static List<int> Ids = new List<int>();

        public Shape(float x, float y, float[] sides)
        {
            this.X = x;
            this.Y = y;
            this.Sides = sides;

            this.GenerateId();

            this.area = 0.0f;
        }

        public int Id { get; set; }
        public float X { get; }
        public float Y { get; }
        public virtual double Area { get; set; }

        public float[] Sides { get; } 

        public virtual bool ContainPoint(float x, float y)
        {
            return true;
        }


        public string ToStringWithArea()
        {
            return String.Concat(this.ToString(), " | Area: ", this.Area);
        }

        private void GenerateId()
        {
            int tmpId = 1;
            if (Shape.Ids.Count() > 0)
            {
                tmpId = Shape.Ids.Max();
            }
            while (Shape.Ids.Contains(tmpId))
            {
                tmpId++;
            }
            Shape.Ids.Add(tmpId);
            this.Id = tmpId;
        }
    }
}

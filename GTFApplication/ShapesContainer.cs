using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication
{
    public class ShapesContainer
    {
        public ShapesContainer()
        {
            this.Shapes = new List<Shape>();
        }

        public List<Shape> Shapes { get; set; }

        public string AddShape(Shape shape)
        {
            this.Shapes.Add(shape);
            return shape.ToString();
        }

        public string deleteShape(int id)
        {
            if(!this.Shapes.Exists(s => s.Id == id))
            {
                return String.Format("Shape with id {0} was not found.", id);
            }
            var onlyMatch = this.Shapes.Single(s => s.Id == id);
            this.Shapes.Remove(onlyMatch);

            return String.Format("String with id {0} was removed.", id);

        }

        public IEnumerable<string> GetShapeList()
        {
            for(int i = 0; i < this.Shapes.Count; i++)
            {
                yield return this.Shapes[i].ToString();
            }
        }

        public IEnumerable<string> FindInPoint(float x, float y)
        {
            var selectedShapes = this.Shapes.Where(shape => shape.ContainPoint(x, y));
            double totalArea = 0;

            for (int i = 0; i < selectedShapes.Count(); i++)
            {
                var tmpShape = selectedShapes.ElementAt(i);
                totalArea += tmpShape.Area;
                yield return tmpShape.ToStringWithArea();
            }

            yield return String.Format("Total Area of shapes: {0}", totalArea);
        }

    }
}

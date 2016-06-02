using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class RectangleExpression : IExpression
    {
        public Shape Interpret(string expression)
        {
            Rectangle rectangle;

            string[] parameters = expression.Split(' ');
            if (parameters.Count() != 4)
            {
                throw new ArgumentException("Wrong number of arguments for creating a rectangle, please enter the format 'rectangle x y side1 side2'");
            }

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the rectangle should be of type float. 'rectangle x y side1 side2'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the rectangle should be of type float. 'rectangle x y side1 side2'");
            }

            float side1;
            if (!float.TryParse(parameters[2], out side1))
            {
                throw new ArgumentException("Wrong format of arguments, params side1 of the rectangle should be of type float. 'rectangle x y side1 side2'");
            }

            float side2;
            if (!float.TryParse(parameters[3], out side2))
            {
                throw new ArgumentException("Wrong format of arguments, params side2 of the rectangle should be of type float. 'rectangle x y side1 side2'");
            }

            rectangle = new Rectangle(x, y, side1, side2);

            return rectangle;
        }
    }
}

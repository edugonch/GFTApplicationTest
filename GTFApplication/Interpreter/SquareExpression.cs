using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class SquareExpression : IExpression
    {
        public Shape Interpret(string expression)
        {
            Square square;

            string[] parameters = expression.Split(' ');
            if (parameters.Count() != 3)
            {
                throw new ArgumentException("Wrong number of arguments for creating a square, please enter the format 'square x y side'");
            }

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the square should be of type float. 'square x y side'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the square should be of type float. 'square x y side'");
            }

            float side;
            if (!float.TryParse(parameters[2], out side))
            {
                throw new ArgumentException("Wrong format of arguments, params side of the square should be of type float. 'square x y side'");
            }

            square = new Square(x, y, side);

            return square;
        }
    }
}

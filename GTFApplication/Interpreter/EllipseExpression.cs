using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    class EllipseExpression : IExpression
    {
        public Shape Interpret(string expression)
        {
            Ellipse ellipse;

            string[] parameters = expression.Split(' ');
            if (parameters.Count() != 4)
            {
                throw new ArgumentException("Wrong number of arguments for creating a ellipse, please enter the format 'ellipse x y radiusMin radiusMax'");
            }

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the ellipse should be of type float. 'ellipse x y radiusMin radiusMax'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the ellipse should be of type float. 'ellipse x y radiusMin radiusMax'");
            }

            float radiusMin;
            if (!float.TryParse(parameters[2], out radiusMin))
            {
                throw new ArgumentException("Wrong format of arguments, params radiusMin of the ellipse should be of type float. 'ellipse x y radiusMin radiusMax'");
            }

            float radiusMax;
            if (!float.TryParse(parameters[2], out radiusMax))
            {
                throw new ArgumentException("Wrong format of arguments, params radiusMax of the ellipse should be of type float. 'ellipse x y radiusMin radiusMax'");
            }

            ellipse = new Ellipse(x, y, radiusMin, radiusMax);

            return ellipse;
        }
    }
}

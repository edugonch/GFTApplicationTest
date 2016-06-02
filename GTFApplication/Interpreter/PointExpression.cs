using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class PointExpression
    {
        public float[] Interpret(string expression)
        {
            string[] parameters = expression.Split(' ');

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the point shold be of type float. 'x y'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the point shold be of type float. 'x y'");
            }

            return new float[] { x, y };
        }
    }
}

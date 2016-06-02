using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{

    public class CircleExpression : IExpression
    {

        public Shape Interpret(string expression)
        {
            Circle circle;

            string[] parameters = expression.Split(' ');
            if(parameters.Count() != 3)
            {
                throw new ArgumentException("Wrong number of arguments for creating a circle, please enter the format 'circle x y radius'");
            }

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the circle shold be of type float. 'circle x y radius'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the circle shold be of type float. 'circle x y radius'");
            }

            float radius;
            if (!float.TryParse(parameters[2], out radius))
            {
                throw new ArgumentException("Wrong format of arguments, params radius of the circle shold be of type float. 'circle x y radius'");
            }

            circle = new Circle(x,y,radius);

            return circle;
        }
    }
}

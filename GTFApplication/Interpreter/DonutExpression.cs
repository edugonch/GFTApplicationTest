using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class DonutExpression : IExpression
    {
        public Shape Interpret(string expression)
        {
            Donut donut;

            string[] parameters = expression.Split(' ');
            if (parameters.Count() != 4)
            {
                throw new ArgumentException("Wrong number of arguments for creating a donut, please enter the format 'donut x y radius1 radius2'");
            }

            float x;
            if (!float.TryParse(parameters[0], out x))
            {
                throw new ArgumentException("Wrong format of arguments, params x of the donut shold be of type float. 'donut x y radius1 radius2'");
            }

            float y;
            if (!float.TryParse(parameters[1], out y))
            {
                throw new ArgumentException("Wrong format of arguments, params y of the donut shold be of type float. 'donut x y radius1 radius2'");
            }

            float radius1;
            if (!float.TryParse(parameters[2], out radius1))
            {
                throw new ArgumentException("Wrong format of arguments, params radius1 of the donut shold be of type float. 'donut x y radius1 radius2'");
            }

            float radius2;
            if (!float.TryParse(parameters[3], out radius2))
            {
                throw new ArgumentException("Wrong format of arguments, params radius2 of the donut shold be of type float. 'donut x y radius1 radius2'");
            }

            donut = new Donut(x, y, radius1, radius2);

            return donut;
        }
    }
}

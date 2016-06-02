using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class TriangleExpression : IExpression
    {
        public Shape Interpret(string expression)
        {
            Triangle triangle;

            string[] parameters = expression.Split(' ');
            if (parameters.Count() != 6)
            {
                throw new ArgumentException("Wrong number of arguments for creating a triangle, please enter the format 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float x_vertice1;
            if (!float.TryParse(parameters[0], out x_vertice1))
            {
                throw new ArgumentException("Wrong format of arguments, params x_vertice1 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float y_vertice1;
            if (!float.TryParse(parameters[1], out y_vertice1))
            {
                throw new ArgumentException("Wrong format of arguments, params y_vertice1 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float x_vertice2;
            if (!float.TryParse(parameters[2], out x_vertice2))
            {
                throw new ArgumentException("Wrong format of arguments, params x_vertice2 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float y_vertice2;
            if (!float.TryParse(parameters[3], out y_vertice2))
            {
                throw new ArgumentException("Wrong format of arguments, params y_vertice2 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float x_vertice3;
            if (!float.TryParse(parameters[4], out x_vertice3))
            {
                throw new ArgumentException("Wrong format of arguments, params x_vertice3 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            float y_vertice3;
            if (!float.TryParse(parameters[5], out y_vertice3))
            {
                throw new ArgumentException("Wrong format of arguments, params y_vertice3 of the triangle should be of type float. 'triangle x_vertice1 y_vertice1 x_vertice2 y_vertice2 x_vertice3 y_vertice3'");
            }

            triangle = new Triangle(x_vertice1, y_vertice1, x_vertice2, y_vertice2, x_vertice3, y_vertice3);

            return triangle;
        }
    }
}

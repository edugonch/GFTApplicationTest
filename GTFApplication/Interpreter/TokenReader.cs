using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public class TokenReader
    {
        public static int ReadId(string strExpression)
        {
            int id;
            if (!int.TryParse(strExpression, out id))
            {
                throw new ArgumentException("Id not valid, please enter a valid id");
            }

            return id;
        }
        public static float[] ReadPoint(string strExpression)
        {
            PointExpression expression = new PointExpression();

            return expression.Interpret(strExpression);
        }

        public static Shape ReadToken(string strExpression)
        {

            IExpression expression;
            Shape shape;
            string strShape = "";

            if (strExpression.StartsWith("circle")) 
            {
                expression = new CircleExpression();
                strShape = "circle";
            }
            else if (strExpression.StartsWith("square"))  
            {
                expression = new SquareExpression();
                shape = expression.Interpret(strExpression.Replace("square", "").Trim());
                strShape = "square";
            }
            else if (strExpression.StartsWith("rectangle"))
            {
                expression = new RectangleExpression();
                strShape = "rectangle";
            }
            else if (strExpression.StartsWith("triangle"))
            {
                expression = new TriangleExpression();
                strShape = "triangle";
            }
            else if (strExpression.StartsWith("donut"))
            {
                expression = new DonutExpression();
                strShape = "donut";
            }
            else if (strExpression.StartsWith("ellipse"))
            {
                expression = new EllipseExpression();
                strShape = "ellipse";
            }
            else
            {
                throw new ArgumentException("Wrong expression for shape, please enter, circle, square, rectangle, triangle, donut, for more help, please select help in the menu.");
            }

            shape = expression.Interpret(strExpression.Replace(strShape, "").Trim());

            return shape;
        }
    }
}

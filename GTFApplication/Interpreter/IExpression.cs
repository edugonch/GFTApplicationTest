using GFTApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTApplication.Interpreter
{
    public interface IExpression
    {
        Shape Interpret(string expression);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurCeinture.Shared
{
    public record Ceinture(IEnumerable<MathExpression> MathExpressions);

    public record MathExpression(int LeftOperand, MathOperator Operator, int RightOperand, int Result);

    public enum MathOperator
    {
        Add , Subtract, Multiply, Divide
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurCeinture.Shared
{
    //public class CeintureRequest(int? NumberOfExpressions, bool? generateAddition = false, bool? generateSubtraction = false, bool? generateMultiplication = true, bool? generateDivision = false);

    public record Ceinture(IEnumerable<MathExpression> MathExpressions);

    public record MathExpression(int LeftOperand, MathOperator Operator, int RightOperand, int Result) {
        public override string ToString() {
            return $"{LeftOperand} {Operator.ToDisplay()} {RightOperand} = {Result}";
        }
    }

    public enum MathOperator
    {
        Add , Subtract, Multiply, Divide
    }

    public static class MathOperatorExtensions {
        public static string ToDisplay(this MathOperator mathOperator) => mathOperator switch {
            MathOperator.Add => "+",
            MathOperator.Divide => "/",
            MathOperator.Multiply => "*",
            MathOperator.Subtract => "-",
            _ => "?"
        };
    }
}

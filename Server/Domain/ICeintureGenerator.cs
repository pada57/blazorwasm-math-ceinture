using GenerateurCeinture.Shared;

namespace GenerateurCeinture.Server.Domain
{
    public interface ICeintureGenerator
    {
        Ceinture? Generate(GenerateCeintureRequest request);

    }

    internal class SimpleCeintureGenerator : ICeintureGenerator
    {
        public Ceinture? Generate(GenerateCeintureRequest request)
        {
            if (request == null) return null;
            if (request.NumberOfExpressions <= 0) return null;


            return new Ceinture(GenerateExpression(request.NumberOfExpressions).ToList());
        }

        private IEnumerable<MathExpression> GenerateExpression(int numberOfExpressions)
        {
            var random = new Random();
            for(var i = 0; i < numberOfExpressions; i++)
            {
                var @operator = (MathOperator)random.Next(4); // TODO add only operator requested
                var leftOperand = random.Next(11); // TODO add as param
                var rightOperand = random.Next(@operator == MathOperator.Divide ? 1 : 0, 11);

                //TODO retry if already in returned operations for Add and Mul

                yield return new MathExpression(leftOperand, @operator, rightOperand, CalculateResult(leftOperand, @operator, rightOperand));
            }
        }

        private int CalculateResult(int leftOperand, MathOperator @operator, int rightOperand)
        {
            return @operator switch
            {
                MathOperator.Add => leftOperand + rightOperand,
                MathOperator.Multiply => leftOperand * rightOperand,
                MathOperator.Subtract => leftOperand - rightOperand,
                MathOperator.Divide => leftOperand / rightOperand,
                _ => throw new NotImplementedException($"Unknown {@operator}"),
            };
        }
    }
}

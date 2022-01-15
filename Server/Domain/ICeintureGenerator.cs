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
            if ((request.CeintureRequest.NumberOfExpressions ?? 0) <= 0) return null;


            return new Ceinture(GenerateExpression(request.CeintureRequest).ToList());
        }

        private IEnumerable<MathExpression> GenerateExpression(CeintureRequestModel ceintureRequest)
        {
            var allowedOperators = new List<MathOperator>();
            if (ceintureRequest.GenerateAddition) allowedOperators.Add(MathOperator.Add);
            if (ceintureRequest.GenerateSubstraction) allowedOperators.Add(MathOperator.Subtract);
            if (ceintureRequest.GenerateMultiplication) allowedOperators.Add(MathOperator.Multiply);
            if (ceintureRequest.GenerateDivision) allowedOperators.Add(MathOperator.Divide);

            var random = new Random();
            var countOperators = allowedOperators.Count;
            for (var i = 0; i < ceintureRequest.NumberOfExpressions; i++)
            {
                var @operator = allowedOperators[random.Next(countOperators)];                    
                var leftOperand = @operator != MathOperator.Divide ? random.Next(1, 11) : random.Next(1,101); // TODO add as param
                var rightOperand = random.Next(@operator == MathOperator.Divide ? 1 : 0, 11);

                if (@operator == MathOperator.Divide && leftOperand < rightOperand) {
                    (leftOperand, rightOperand) = (rightOperand, leftOperand);
                }

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

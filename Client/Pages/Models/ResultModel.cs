using GenerateurCeinture.Shared;
using System.ComponentModel.DataAnnotations;

namespace GenerateurCeinture.Client.Pages.Models
{
    public class ResultModel
    {
        private readonly List<ResultItem> items;
        private readonly List<string> errors = new();

        public ResultModel(Ceinture ceinture)
        {
            items = ceinture.MathExpressions.Select(exp => new ResultItem(exp)).ToList();
        }

        //[ValidateComplexType]
        public IEnumerable<ResultItem> Items => items.AsReadOnly();

        public IEnumerable<string> Errors => errors.AsReadOnly();


        public ResultModel AddError(string error) {
            errors.Add(error);
            return this;
        }
    }

    public class ResultItem
    {
        public ResultItem(MathExpression mathExpression) => Expression = mathExpression;

        public MathExpression Expression { get; }

        public int ResultatAttendu => Expression.Result;

        //[Compare("ResultatAttendu", ErrorMessage = "Mauvais résultat")]
        public int? Resultat { get; set; }
    }
}

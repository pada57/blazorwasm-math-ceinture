using System.ComponentModel.DataAnnotations;

namespace GenerateurCeinture.Shared {
    public class CeintureRequestModel {
        [Required(ErrorMessage = "Le nombre de calculs est requis")]
        public int? NumberOfExpressions { get; set; }

        [Required(ErrorMessage = "Le temps est requis")]
        public int? Temps { get; set; }

        public bool GenerateAddition { get; set; }
        public bool GenerateSubstraction { get; set; }
        public bool GenerateDivision { get; set; }
        public bool GenerateMultiplication { get; set; }
    }
}

using GenerateurCeinture.Shared;
using MediatR;

namespace GenerateurCeinture.Server.Domain
{
    public record GenerateCeintureRequest(int NumberOfExpressions) : IRequest<Ceinture?>
    {

        //TODO add allowed Operators etc...


        internal class GenerateCeintureRequestHandler : IRequestHandler<GenerateCeintureRequest, Ceinture?>
        {
            private readonly ICeintureGenerator ceintureGenerator;

            public GenerateCeintureRequestHandler(ICeintureGenerator ceintureGenerator)
            {
                this.ceintureGenerator = ceintureGenerator;
            }

            public Task<Ceinture?> Handle(GenerateCeintureRequest request, CancellationToken cancellationToken)
            {
                return Task.FromResult(ceintureGenerator.Generate(request));
            }
        }
    }
}

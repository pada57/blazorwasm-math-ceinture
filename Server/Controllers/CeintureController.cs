using GenerateurCeinture.Server.Domain;
using GenerateurCeinture.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenerateurCeinture.Server.Controllers
{
    [Route("api/ceinture")]
    [ApiController]
    public class CeintureController : ControllerBase
    {
        private readonly IMediator mediator;

        public CeintureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<Ceinture?> GenerateCeinture([FromQuery] CeintureRequestModel ceintureRequest)
        {
            var response = await mediator.Send(new GenerateCeintureRequest(ceintureRequest));
            return response;
        }
    }
}

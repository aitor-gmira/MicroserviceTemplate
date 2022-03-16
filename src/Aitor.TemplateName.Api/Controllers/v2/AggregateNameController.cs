using System.Threading.Tasks;
using Aitor.TemplateName.Models.Dto;
using Aitor.TemplateName.Models.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.Api.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/aggregateNames")]
    [Version2]
    public class AggregateNameController : ControllerBase
    {
        private readonly ILogger<AggregateNameController> _logger;
        private readonly IMediator _mediator;
        private readonly ISharedResource _sharedResource;

        public AggregateNameController(ILogger<AggregateNameController> logger, IMediator mediator, ISharedResource sharedResource)
        {
            _logger = logger;
            _mediator = mediator;
            _sharedResource = sharedResource;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(AggregateNameDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> TestV2()
        {
            return Ok(_sharedResource.ExampleText);
        }
    }
}

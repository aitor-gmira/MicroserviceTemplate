using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.App.Commands.AggregateName;
using Aitor.TemplateName.App.Queries;
using Aitor.TemplateName.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/aggregateNames")]
    [Version1]
    public class AggregateNameController : ControllerBase
    {
        private readonly ILogger<AggregateNameController> _logger;
        private readonly IMediator _mediator;

        public AggregateNameController(ILogger<AggregateNameController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AggregateNameDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetExampleById(int id)
        {
            var getExampleByIdQuery = new GetAggregateNameByIdQuery()
            {
                Id = id,
            };

            var result = await _mediator.Send(getExampleByIdQuery);

            if (result.Type == QueryResultTypeEnum.InvalidInput)
            {
                return BadRequest();
            }

            if (result.Type == QueryResultTypeEnum.NotFound)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Post(AggregateNameDto dto)
        {

            if (dto == null)
            {
                return BadRequest("The AggregateNameDto is mandatory");
            }

            var result = await _mediator.Send(new AddAggregateNameCommand { Dto = dto });

            if (result.Type == CommandResultTypeEnum.InvalidInput)
            {
                return BadRequest();
            }

            if (result.Type == CommandResultTypeEnum.NotFound)
            {
                return NotFound();
            }

            return Created($"api/v1/aggregateNames/{result.Result.Name}", result.Result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Put(UpdateAggregateNameDto dto)
        {

            if (dto == null)
            {
                return BadRequest("The UpdateAggregateNameDto is mandatory");
            }

            var result = await _mediator.Send(new UpdateAggregateNameCommand { Dto = dto });

            if (result.Type == CommandResultTypeEnum.InvalidInput)
            {
                return BadRequest();
            }

            if (result.Type == CommandResultTypeEnum.NotFound)
            {
                return NotFound();
            }

            return Ok(result.Result);
        }
    }
}

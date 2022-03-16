using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.App.Services;
using Aitor.TemplateName.Models.Dto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.App.Commands.AggregateName
{
    public class UpdateAggregateNameCommandHandler : IRequestHandler<UpdateAggregateNameCommand, CommandResult<AggregateNameDto>>
    {
        private readonly IAggregateNameAppService _appService;
        private readonly ILogger<AddAggregateNameCommandHandler> _logger;

        public UpdateAggregateNameCommandHandler(IAggregateNameAppService appService, ILogger<AddAggregateNameCommandHandler> logger)
        {
            _appService = appService;
            _logger = logger;
        }

        public async Task<CommandResult<AggregateNameDto>> Handle(UpdateAggregateNameCommand request, CancellationToken cancellationToken)
        {

            var result = await _appService.UpdateAggregateName(request.Dto);

            if (result == null)
            {
                return new CommandResult<AggregateNameDto>(result: result, type: CommandResultTypeEnum.NotFound);
            }

            return new CommandResult<AggregateNameDto>(result: result, type: CommandResultTypeEnum.Success);
        }
    }
}

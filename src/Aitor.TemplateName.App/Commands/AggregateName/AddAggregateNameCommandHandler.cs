using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.App.Services;
using Aitor.TemplateName.Models.Dto;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.App.Commands.AggregateName
{
    public class AddAggregateNameCommandHandler : IRequestHandler<AddAggregateNameCommand, CommandResult<AggregateNameDto>>
    {
        private readonly IAggregateNameAppService _appService;
        private readonly IValidator<AddAggregateNameCommand> _validator;
        private readonly ILogger<AddAggregateNameCommandHandler> _logger;

        public AddAggregateNameCommandHandler(IAggregateNameAppService appService, IValidator<AddAggregateNameCommand> validator, ILogger<AddAggregateNameCommandHandler> logger)
        {
            _appService = appService;
            _validator = validator;
            _logger = logger;
        }

        public async Task<CommandResult<AggregateNameDto>> Handle(AddAggregateNameCommand request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Add aggregateName produced errors on validation {Errors}", validation.ToString());
                return new CommandResult<AggregateNameDto>(result: default(AggregateNameDto), type: CommandResultTypeEnum.InvalidInput);
            }

            var result = await _appService.AddAggregateName(request.Dto);

            if (result == null)
            {
                return new CommandResult<AggregateNameDto>(result: result, type: CommandResultTypeEnum.NotFound);
            }

            return new CommandResult<AggregateNameDto>(result: result, type: CommandResultTypeEnum.Success);
        }
    }
}

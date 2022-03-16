using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.Models.Dto;
using MediatR;

namespace Aitor.TemplateName.App.Commands.AggregateName
{
    public class UpdateAggregateNameCommand : IRequest<CommandResult<AggregateNameDto>>
    {
        public UpdateAggregateNameDto Dto { get; set; }
    }
}

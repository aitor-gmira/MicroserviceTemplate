using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.Models.Dto;
using MediatR;

namespace Aitor.TemplateName.App.Commands.AggregateName
{
    public class AddAggregateNameCommand : IRequest<CommandResult<AggregateNameDto>>
    {
        public AggregateNameDto Dto { get; set; }
    }
}

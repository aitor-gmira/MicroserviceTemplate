using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.Models.Dto;
using MediatR;

namespace Aitor.TemplateName.App.Queries
{
    public class GetAggregateNameByIdQuery : IRequest<QueryResult<AggregateNameDto>>
    {
        public int Id { get; set; }
    }
}

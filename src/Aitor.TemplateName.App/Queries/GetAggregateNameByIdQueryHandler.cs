using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.Dom.Contracts.Query;
using Aitor.TemplateName.Models.Dto;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.App.Queries
{
    public class GetAggregateNameByIdQueryHandler : IRequestHandler<GetAggregateNameByIdQuery, QueryResult<AggregateNameDto>>
    {
        private readonly IValidator<GetAggregateNameByIdQuery> _validator;
        private readonly IAggregateNameQueryRepository _queryRepository;
        private readonly ILogger<GetAggregateNameByIdQueryHandler> _logger;

        public GetAggregateNameByIdQueryHandler(ILogger<GetAggregateNameByIdQueryHandler> logger, IAggregateNameQueryRepository queryRepository, IValidator<GetAggregateNameByIdQuery> validator)
        {
            _logger = logger;
            _queryRepository = queryRepository;
            _validator = validator;
        }

        public async Task<QueryResult<AggregateNameDto>> Handle(GetAggregateNameByIdQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get aggregateName by id with id {Id} produced errors on validation {Errors}", request.Id, validation.ToString());
                return new QueryResult<AggregateNameDto>(result: default(AggregateNameDto), type: QueryResultTypeEnum.InvalidInput);
            }

            var result = await _queryRepository.GetById(request.Id);

            if (result == null)
            {
                return new QueryResult<AggregateNameDto>(result: result, type: QueryResultTypeEnum.NotFound);
            }

            return new QueryResult<AggregateNameDto>(result: result, type: QueryResultTypeEnum.Success);
        }
    }
}

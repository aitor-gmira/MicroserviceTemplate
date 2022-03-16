using System.Threading.Tasks;
using Aitor.BuildingBlocks.App;
using Aitor.BuildingBlocks.Dom;
using Aitor.TemplateName.Dom.Contracts;
using Aitor.TemplateName.Dom.Entities.AggregateName;
using Aitor.TemplateName.Models.Dto;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.App.Services
{
    public class AggregateNameAppService : BaseAppService<AggregateNameAppService>, IAggregateNameAppService
    {
        private readonly IAggregateNameRepository _aggregateNameRepository;

        public AggregateNameAppService(IAggregateNameRepository aggregateNameRepository, IUnitOfWork unitOfWork, ILogger<AggregateNameAppService> logger)
            : base(unitOfWork, logger)
        {
            _aggregateNameRepository = aggregateNameRepository;
        }

        public async Task<AggregateNameDto> AddAggregateName(AggregateNameDto dto)
        {
            AggregateNameDto result = null;

            var aggregateName = new AggregateName(dto.Name, new AggregateNameValue("Mi calle", "Zaragoza"), null);

            await _aggregateNameRepository.Add(aggregateName);

            if (await _unitOfWork.CommitAsync() > 0)
                result = MapDto(aggregateName);

            return result;
        }

        public async Task<AggregateNameDto> UpdateAggregateName(UpdateAggregateNameDto dto)
        {
            AggregateNameDto result = null;

            var aggregateName = await _aggregateNameRepository.Get(dto.AggregateNameId, "AggregateNameValue");

            if (aggregateName != null)
            {
                aggregateName.Update(new AggregateNameValue(dto.Street, dto.City));

                if (await _aggregateNameRepository.Update(aggregateName) > 0)
                {
                    if (await _unitOfWork.CommitAsync() > 0)
                        result = MapDto(aggregateName);
                }
            }

            return result;
        }

        private AggregateNameDto MapDto(AggregateName aggregateName)
        {
            return new AggregateNameDto
            {
                Name = aggregateName.Name,
                IsValid = aggregateName.IsValid
            };
        }
    }
}

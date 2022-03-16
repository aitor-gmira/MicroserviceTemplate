using System.Threading.Tasks;
using Aitor.TemplateName.Models.Dto;

namespace Aitor.TemplateName.App.Services
{
    public interface IAggregateNameAppService
    {
        Task<AggregateNameDto> AddAggregateName(AggregateNameDto dto);
        Task<AggregateNameDto> UpdateAggregateName(UpdateAggregateNameDto dto);
    }
}

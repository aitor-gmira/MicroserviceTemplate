using System.Collections.Generic;
using System.Threading.Tasks;
using Aitor.TemplateName.Models.Dto;

namespace Aitor.TemplateName.Dom.Contracts.Query
{
    public interface IAggregateNameQueryRepository
    {
        Task<IEnumerable<AggregateNameDto>> GetAll();
        Task<AggregateNameDto> GetById(int id);
        Task<AggregateNameDto> GetByName(string name);
    }
}

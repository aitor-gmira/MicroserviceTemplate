using Aitor.BuildingBlocks.Data;
using Aitor.TemplateName.Dom.Contracts;
using Aitor.TemplateName.Dom.Entities.AggregateName;

namespace Aitor.TemplateName.Data.Repository
{
    public class AggregateNameRepository : RepositoryBase<AggregateName>, IAggregateNameRepository
    {
        public AggregateNameRepository(AggregateNameContext context) : base(context)
        {
        }
    }
}

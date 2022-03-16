using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.Data;
using Aitor.TemplateName.Dom.Contracts.Query;
using Aitor.TemplateName.Models.Dto;
using Dapper;

namespace Aitor.TemplateName.Data.Repository.Query
{
    public class AggregateNameQueryRepository : QueryRepositoryBase, IAggregateNameQueryRepository
    {
        public AggregateNameQueryRepository(IConnectionProvider connectionProvider) : base(connectionProvider) { }
        public async Task<AggregateNameDto> GetById(int id)
        {
            const string sql = "AggregateName.GetTagTypeById";

            using (var conn = _connectionProvider.CreateConnection("Connections:AggregateNameReadOnly"))
            {
                AggregateNameDto result = await conn.QueryFirstOrDefaultAsync<AggregateNameDto>(sql, new { id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<AggregateNameDto>> GetAll() => throw new NotImplementedException();
        public async Task<AggregateNameDto> GetByName(string name) => throw new NotImplementedException();
    }
}

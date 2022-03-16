namespace Aitor.BuildingBlocks.Data
{
    public abstract class QueryRepositoryBase
    {
        protected readonly IConnectionProvider _connectionProvider;

        public QueryRepositoryBase(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
    }
}

using System.Data;

namespace Aitor.BuildingBlocks.Data
{
    public interface IConnectionProvider
    {
        IDbConnection CreateConnection(string connectionName);

        IDbConnection CreateConnectionWithConnectionString(string connectionString);
    }
}

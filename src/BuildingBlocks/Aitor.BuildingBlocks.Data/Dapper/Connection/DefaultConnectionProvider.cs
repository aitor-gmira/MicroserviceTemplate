using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Aitor.BuildingBlocks.Data
{
    public class DefaultConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public DefaultConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection(string connectionName)
        {
            var connectionString = string.Empty;

            connectionString = _configuration.GetSection(connectionName).Value;

            return CreateConnectionWithConnectionString(connectionString);
        }

        public IDbConnection CreateConnectionWithConnectionString(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

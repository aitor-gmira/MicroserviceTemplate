using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Aitor.TemplateName.Data
{
    public class AggregateNameContextDesignFactory : IDesignTimeDbContextFactory<AggregateNameContext>
    {
        private readonly string _connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;database=TemplateName;trusted_connection=yes;";
        private readonly string _migrationTable = "__EFMigrationsHistory";
        private readonly string _schema = "TemplateName";

        public AggregateNameContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AggregateNameContext>()
                .UseSqlServer(_connectionString, x => x.MigrationsHistoryTable(_migrationTable, _schema));

            return new AggregateNameContext(optionsBuilder.Options);
        }
    }
}

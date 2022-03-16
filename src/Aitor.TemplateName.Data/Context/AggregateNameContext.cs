using Aitor.TemplateName.Data.Context.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Aitor.TemplateName.Data
{
    public class AggregateNameContext : DbContext
    {
        public AggregateNameContext(DbContextOptions<AggregateNameContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TemplateName");

            modelBuilder.ApplyConfiguration(new AggregateNameEFConfig());
            modelBuilder.ApplyConfiguration(new AggregateNameItemEFConfig());
            modelBuilder.ApplyConfiguration(new AggregateNameStatusEFConfig());
        }
    }
}

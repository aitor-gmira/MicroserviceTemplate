using Aitor.TemplateName.Dom.Entities.AggregateName;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aitor.TemplateName.Data.Context.EntityConfigurations
{
    public class AggregateNameStatusEFConfig : IEntityTypeConfiguration<AggregateNameStatus>
    {
        public void Configure(EntityTypeBuilder<AggregateNameStatus> aggregateNameStatusConfiguration)
        {
            aggregateNameStatusConfiguration.ToTable("AggregateNameStatus");

            aggregateNameStatusConfiguration.HasKey(e => e.Id);

            aggregateNameStatusConfiguration.Property(e => e.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            aggregateNameStatusConfiguration.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

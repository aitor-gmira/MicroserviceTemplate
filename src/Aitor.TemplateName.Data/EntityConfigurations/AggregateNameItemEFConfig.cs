using Aitor.TemplateName.Dom.Entities.AggregateName;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aitor.TemplateName.Data.Context.EntityConfigurations
{
    public class AggregateNameItemEFConfig : IEntityTypeConfiguration<AggregateNameItem>
    {
        public void Configure(EntityTypeBuilder<AggregateNameItem> aggregateNameItemConfiguration)
        {
            aggregateNameItemConfiguration.ToTable("SQ_AggregateNameItems");
            aggregateNameItemConfiguration.HasKey(e => e.Id);
            aggregateNameItemConfiguration.Ignore(e => e.DomainEvents);
            aggregateNameItemConfiguration.Property(e => e.Id).UseHiLo("SQ_AggregateNameItems");

            aggregateNameItemConfiguration.Property(e => e.Url).HasMaxLength(150).IsRequired();
            aggregateNameItemConfiguration.Property(e => e.Units).HasMaxLength(3).IsRequired();
        }
    }
}

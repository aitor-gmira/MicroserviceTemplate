using Aitor.BuildingBlocks.Dom;
using Aitor.TemplateName.Dom.Entities.AggregateName;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aitor.TemplateName.Data.Context.EntityConfigurations
{
    public class AggregateNameEFConfig : IEntityTypeConfiguration<AggregateName>
    {
        public void Configure(EntityTypeBuilder<AggregateName> aggregateNameConfiguration)
        {
            aggregateNameConfiguration.ToTable("AggregateNames");
            aggregateNameConfiguration.HasKey(e => e.Id);
            aggregateNameConfiguration.Ignore(e => e.DomainEvents);

            aggregateNameConfiguration.Property(e => e.Id)
                .UseHiLo("SQ_AggregateNames");

            aggregateNameConfiguration
            .Property(o => o.TemplateId)
            .HasConversion(new ExternalIdentityValueConverter());

            aggregateNameConfiguration.Property(e => e.Name).HasMaxLength(120).IsRequired();
            aggregateNameConfiguration.HasMany(e => e.Items).WithOne().IsRequired();


            aggregateNameConfiguration
                .OwnsOne(e => e.AggregateNameValue, v =>
                {
                    v.Property(v => v.City).HasMaxLength(120).IsRequired();
                    v.Property(v => v.Street).HasMaxLength(120).IsRequired();
                    v.ToTable("AggregateNamesValue");
                });

            aggregateNameConfiguration.Property(e => e.AggregateNameStatus).HasColumnName("AggregateNameStatusId").IsRequired()
                .HasConversion(e => e.Id, e => AggregateNameStatus.FromId(e));

        }
    }
}

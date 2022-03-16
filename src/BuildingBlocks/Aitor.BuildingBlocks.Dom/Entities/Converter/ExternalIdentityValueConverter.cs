using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aitor.BuildingBlocks.Dom
{
    public class ExternalIdentityValueConverter : ValueConverter<ExternalIdentity, Guid>
    {
        public ExternalIdentityValueConverter(ConverterMappingHints mappingHints = null)
        : base(
            id => id.Uuid,
            value => new ExternalIdentity(value),
            mappingHints
        )
        { }
    }
}

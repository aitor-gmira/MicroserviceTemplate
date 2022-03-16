using System.Collections.Generic;
using Aitor.BuildingBlocks.Dom;

namespace Aitor.TemplateName.Dom.Entities.AggregateName
{
    public class AggregateNameValue : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }

        public AggregateNameValue() { }

        public AggregateNameValue(string street, string city)
        {
            Street = street;
            City = city;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
        }
    }
}

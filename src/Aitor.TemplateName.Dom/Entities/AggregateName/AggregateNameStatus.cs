using System;
using System.Collections.Generic;
using System.Linq;
using Aitor.BuildingBlocks.Dom;
using Aitor.TemplateName.Dom.Exceptions;

namespace Aitor.TemplateName.Dom.Entities.AggregateName
{
    public class AggregateNameStatus : Enumeration
    {
        public static AggregateNameStatus Accepted = new AggregateNameStatus(1, nameof(Accepted).ToLowerInvariant());
        public static AggregateNameStatus Pending = new AggregateNameStatus(2, nameof(Pending).ToLowerInvariant());

        public AggregateNameStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<AggregateNameStatus> List() => new[] { Accepted, Pending };

        public static AggregateNameStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new TemplateNameDomainException($"Possible values for AggregateNameStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static AggregateNameStatus FromId(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new TemplateNameDomainException($"Possible values for AggregateNameStatus: {string.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}

using System.Collections.Generic;
using Aitor.BuildingBlocks.Dom;
using Aitor.TemplateName.Dom.Exceptions;

namespace Aitor.TemplateName.Dom.Entities.AggregateName
{
    public class AggregateName : AggregateRoot
    {
        #region Properties

        public ExternalIdentity TemplateId { get; private set; }
        public string Name { get; private set; }
        public bool IsValid { get; private set; }
        public AggregateNameValue AggregateNameValue { get; private set; }
        public AggregateNameStatus AggregateNameStatus { get; private set; }

        protected readonly List<AggregateNameItem> _items;
        public IReadOnlyCollection<AggregateNameItem> Items => _items.AsReadOnly();

        #endregion

        #region Constructor

        protected AggregateName()
        {
            _items = new List<AggregateNameItem>();
            TemplateId = new ExternalIdentity();
            IsValid = true;
        }

        public AggregateName(string name, AggregateNameValue aggregateNameValue, AggregateNameStatus templateStatus)
            : this()
        {
            Validate(name);

            Name = name;
            AggregateNameValue = aggregateNameValue;
            AggregateNameStatus = templateStatus ?? AggregateNameStatus.Pending;
        }

        #endregion

        #region Domain Operations

        public void Update(AggregateNameValue aggregateNameValue)
        {
            AggregateNameValue = aggregateNameValue;
        }

        #endregion

        #region Validation

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new TemplateNameDomainException($"Invalid name: {name}");
        }

        #endregion
    }
}

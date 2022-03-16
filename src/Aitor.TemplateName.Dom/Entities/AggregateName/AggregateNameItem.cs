using Aitor.BuildingBlocks.Dom;
using Aitor.TemplateName.Dom.Exceptions;

namespace Aitor.TemplateName.Dom.Entities.AggregateName
{
    public class AggregateNameItem : Entity
    {
        #region Properties

        public string Url { get; private set; }
        public int Units { get; private set; }

        #endregion

        #region Constructor

        protected AggregateNameItem() { }

        public AggregateNameItem(string url, int units)
        {
            Validate(url, units);

            Url = url;
            Units = units;
        }

        #endregion

        #region Domain Operations
        #endregion

        #region Validation

        private void Validate(string url, int units)
        {
            if (units <= 0)
                throw new TemplateNameDomainException($"Invalid number of units: {units}");

            if (string.IsNullOrWhiteSpace(url))
                throw new TemplateNameDomainException($"Invalid url: {url}");
        }

        #endregion
    }
}

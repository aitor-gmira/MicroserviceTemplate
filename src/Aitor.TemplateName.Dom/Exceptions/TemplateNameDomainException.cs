using System;

namespace Aitor.TemplateName.Dom.Exceptions
{
    public class TemplateNameDomainException : Exception
    {
        public TemplateNameDomainException()
        { }

        public TemplateNameDomainException(string message) : base(message)
        { }

        public TemplateNameDomainException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}

using System;

namespace Aitor.TemplateName.Data.Exceptions
{
    public class TemplateNameDataException : Exception
    {
        public TemplateNameDataException()
        { }

        public TemplateNameDataException(string message) : base(message)
        { }

        public TemplateNameDataException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}

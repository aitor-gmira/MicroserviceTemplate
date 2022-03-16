using Microsoft.AspNetCore.Mvc;

namespace Aitor.TemplateName.Api
{
    public sealed class Version2Attribute : ApiVersionAttribute
    {
        public Version2Attribute() : base("2")
        {
            Deprecated = false;
        }
    }
}

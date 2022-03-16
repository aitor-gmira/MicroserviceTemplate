using Microsoft.AspNetCore.Mvc;

namespace Aitor.TemplateName.Api
{
    public sealed class Version1Attribute : ApiVersionAttribute
    {
        public Version1Attribute() : base("1")
        {
            Deprecated = false;
        }
    }
}

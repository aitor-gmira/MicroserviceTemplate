using Aitor.BuildingBlocks.Internationalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Aitor.TemplateName.Models.Resources
{
    public class SharedResource : BaseResource, ISharedResource
    {
        public SharedResource(IHttpContextAccessor httpcontextAccessor)
            : base(httpcontextAccessor) { }

        public string ExampleText => LocalizationUtils<SharedResource>.GetValue("ExampleText", _httpContextAccessor.HttpContext.Request.Headers.GetCultureInfo());
    }
}

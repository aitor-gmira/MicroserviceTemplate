using Microsoft.AspNetCore.Http;

namespace Aitor.BuildingBlocks.Internationalization
{
    public abstract class BaseResource
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseResource(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;
    }
}

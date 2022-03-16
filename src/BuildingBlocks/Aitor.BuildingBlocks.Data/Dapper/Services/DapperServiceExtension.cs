using Microsoft.Extensions.DependencyInjection;

namespace Aitor.BuildingBlocks.Data
{
    public static class DapperServiceExtension
    {
        public static void AddCustomDapper(this IServiceCollection services)
        {
            services.AddScoped<IConnectionProvider, DefaultConnectionProvider>();
        }
    }
}

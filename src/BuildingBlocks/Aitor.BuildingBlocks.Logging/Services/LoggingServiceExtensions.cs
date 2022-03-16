using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Aitor.BuildingBlocks.Logging
{
    public static class LoggingServiceExtensions
    {
        public static void AddCustomLogging(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, $"{configuration.GetValue("Serilog:environmentConfig", "CO")}:Serilog")
                .CreateLogger();

            services.AddLogging((builder) =>
            {
                builder.AddSerilog(logger);
            });
        }
    }
}

using System;
using Aitor.TemplateName.Api;
using Aitor.TemplateName.Service.Extensions;
using Hellang.Middleware.ProblemDetails;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Aitor.TemplateName.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddRegisterTypes(Configuration);
            ApiConfiguration.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<ExceptionMiddleware>();
            ApiConfiguration.Configure(app, RegisterConfigurations());
        }

        private Func<IApplicationBuilder, IApplicationBuilder> RegisterConfigurations()
        {
            return host =>
            {
                host.UseProblemDetails();
                host.UseRouting();
                host.UseAuthentication();
                host.UseAuthorization();
                host.UseHealthChecks("/health");
                host.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                return host;
            };
        }
    }
}

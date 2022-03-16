using Aitor.BuildingBlocks.Data;
using Aitor.BuildingBlocks.Dom;
using Aitor.BuildingBlocks.Logging;
using Aitor.TemplateName.Api.HealthChecks;
using Aitor.TemplateName.Data;
using Aitor.TemplateName.Data.Repository;
using Aitor.TemplateName.Dom.Contracts;
using Aitor.TemplateName.Models.Configuration;
using Aitor.TemplateName.Models.Resources;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Lamar;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aitor.TemplateName.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRegisterTypes(this ServiceRegistry services, IConfiguration configuration)
        {
            services.Configure<TemplateNameConfiguration>(configuration);
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddHealthChecks().AddCheck<ReadinessCheck>("TemplateName readiness", tags: new[] { "readiness" });
            services.AddCustomLogging(configuration);
            services.AddProblemDetails(opts =>
            {
                opts.IncludeExceptionDetails = (context, ex) =>
                {
                    var environment = context.RequestServices.GetRequiredService<IHostEnvironment>();
                    return environment.IsDevelopment();
                };
            });

            RegisterResources(services);
            RegisterDapper(services);
            RegisterEntityFramework(services, configuration);
            RegisterDependencies(services);

            return services;
        }

        private static void RegisterDependencies(ServiceRegistry services)
        {
            services.Scan(_ =>
            {
                _.TheCallingAssembly();
                _.Assembly("Aitor.TemplateName.App");
                _.Assembly("Aitor.TemplateName.Data");
                _.Assembly("Aitor.TemplateName.Dom");
                _.AddAllTypesOf<IValidator>();
                _.ConnectImplementationsToTypesClosing(typeof(IValidator<>));
                _.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                _.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                _.WithDefaultConventions();
                _.LookForRegistries();
            });

            services.AddTransient<IMediator, Mediator>();
            services.For<ServiceFactory>().Use(ctx => ctx.GetInstance);

        }

        private static void RegisterResources(IServiceCollection services)
        {
            services.AddScoped<ISharedResource, SharedResource>();
            services.AddScoped<IExceptionResource, ExceptionResource>();
        }

        private static void RegisterDapper(IServiceCollection services)
        {
            services.AddCustomDapper();
        }

        private static void RegisterEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AggregateNameContext>(options => options.UseSqlServer(configuration["Connections:TemplateName"]));
            services.AddScoped<IAggregateNameRepository, AggregateNameRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}

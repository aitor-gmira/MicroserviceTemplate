using System;
using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.App.Commands.Readiness;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Aitor.TemplateName.Api.HealthChecks
{
    public class ReadinessCheck : IHealthCheck
    {
        private readonly ILogger<ReadinessCheck> _logger;
        private readonly IMediator _mediator;

        public ReadinessCheck(ILogger<ReadinessCheck> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                _logger.LogInformation("Se lanza el HealthCheck");
                var performReadinessCheckCommand = new PerformReadinessCheckCommand();

                var result = await _mediator.Send(performReadinessCheckCommand);
                if (result.Type != CommandResultTypeEnum.Success)
                {
                    throw new Exception(result.Result);
                }

                return HealthCheckResult.Healthy();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "ReadinessCheck has encountered an error: {0}", e.Message);
                throw;
            }
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.CQRS;
using Aitor.TemplateName.Models.Configuration;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aitor.TemplateName.App.Commands.Readiness
{
    public class PerformReadinessCheckCommandHandler : IRequestHandler<PerformReadinessCheckCommand, CommandResult<string>>
    {
        private readonly TemplateNameConfiguration _configuration;
        private readonly ILogger<PerformReadinessCheckCommandHandler> _logger;

        public PerformReadinessCheckCommandHandler(ILogger<PerformReadinessCheckCommandHandler> logger, IOptions<TemplateNameConfiguration> configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
        }

        public async Task<CommandResult<string>> Handle(PerformReadinessCheckCommand command, CancellationToken cancellationToken)
        {
            var type = _configuration.GetType();

            foreach (var property in type.GetProperties())
            {
                if (property.GetValue(_configuration, null) == null)
                {
                    return new CommandResult<string>(result: $"Configuration Error. Property {property.Name} is null.", type: CommandResultTypeEnum.InvalidInput);
                }
            }

            return new CommandResult<string>(result: string.Empty, type: CommandResultTypeEnum.Success);
        }
    }
}

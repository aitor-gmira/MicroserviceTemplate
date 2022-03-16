using Aitor.BuildingBlocks.CQRS;
using MediatR;

namespace Aitor.TemplateName.App.Commands.Readiness
{
    public class PerformReadinessCheckCommand : IRequest<CommandResult<string>>
    {
    }
}

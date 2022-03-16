using Aitor.BuildingBlocks.Dom;
using Microsoft.Extensions.Logging;

namespace Aitor.BuildingBlocks.App
{
    public abstract class BaseAppService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<T> _logger;

        public BaseAppService(IUnitOfWork unitOfWork, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}

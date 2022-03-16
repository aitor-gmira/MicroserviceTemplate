using System;
using System.Threading;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.Data;
using Aitor.BuildingBlocks.Dom;
using MediatR;

namespace Aitor.TemplateName.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AggregateNameContext _context;
        private readonly IMediator _mediator;
        private bool _disposed = false;

        public UnitOfWork(AggregateNameContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(_context);

            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}

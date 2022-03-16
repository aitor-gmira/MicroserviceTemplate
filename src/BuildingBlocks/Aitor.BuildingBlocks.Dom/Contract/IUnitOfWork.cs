﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aitor.BuildingBlocks.Dom
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aitor.BuildingBlocks.Dom;
using Microsoft.EntityFrameworkCore;

namespace Aitor.BuildingBlocks.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : AggregateRoot
    {
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return 1;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                return 1;
            }

            return 0;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Get(int id, string includeProperties)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                await _context.Entry(entity).Reference(includeProperty).LoadAsync();
            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(string includeProperties)
        {
            var entities = await _context.Set<TEntity>().ToListAsync();

            foreach (var entity in entities)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    await _context.Entry(entity).Reference(includeProperty).LoadAsync();
                }
            }

            return entities;
        }

        public async Task<int> Update(TEntity entity)
        {
            var item = await _context.Set<TEntity>().FindAsync(entity.Id);
            if (entity != null)
            {
                _context.Entry(item).CurrentValues.SetValues(entity);
                return 1;
            }
            
            return 0;
        }
    }
}

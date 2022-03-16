using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aitor.BuildingBlocks.Dom
{
    public interface IRepositoryBase<TEntity> where TEntity : AggregateRoot
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Get(int id, string includeProperties);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(string includeProperties);
        Task<int> Add(TEntity entity);
        Task<int> Delete(int id);
        Task<int> Update(TEntity entity);
    }
}

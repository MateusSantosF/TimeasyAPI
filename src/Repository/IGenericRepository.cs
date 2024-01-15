using System.Linq.Expressions;
using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Repository;
public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<PagedResult<T>> GetPagedAsync(
           int page, int pageSize, Expression<Func<T, bool>>? searchCondition = null,
           Expression<Func<T, object>>? orderBy = null,
           params Expression<Func<T, object>>[] includeProperties);
    public Task<PagedResult<T>> GetPagedAsync(int page, int pageSize);
    public Task<List<T>> GetAllAsync();
    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> searchCondition);
    public Task<T> CreateAsync(T entity);
    public Task<T> Update(T entity);
    public void Delete(T entity);
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using timeasy_api.src.Contexts;
using timeasy_api.src.Core.Pagination;

namespace timeasy_api.src.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private DbSet<T> _entitie;

    public GenericRepository(TimeasyDbContext context)
    {
        DbContext = context;
        _entitie = context.Set<T>();
    }

    public TimeasyDbContext DbContext { get; set; }


    public async Task<T> CreateAsync(T entity)
    {
        try
        {
            await _entitie.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        catch
        {
            throw new Exception("Erro ao criar entidade");
        }
    }


    public void Delete(T entity)
    {
        _entitie.Remove(entity);
        DbContext.SaveChanges();

    }

    public async Task<PagedResult<T>> GetPagedAsync(
        int page, int pageSize, Expression<Func<T, bool>>? searchCondition = null,
        Expression<Func<T, object>>? orderBy = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _entitie.AsNoTracking().Where(e => e.Active == true);

        if (searchCondition != null)
        {
            query = query.Where(searchCondition);
        }
        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        if (orderBy != null)
        {
            query = query.OrderBy(orderBy);
        }

        return await query.GetPagedAsync(page, pageSize);
    }

    public async Task<PagedResult<T>> GetPagedAsync(int page, int pageSize)
    {
        IQueryable<T> query = _entitie.AsNoTracking().Where(e => e.Active == true);

        return await query.GetPagedAsync(page, pageSize);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _entitie.AsNoTracking().Where(e => e.Active == true).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _entitie.AsNoTracking().Where(entitie => entitie.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entitie.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<T> Update(T entity)
    {
        DbContext.Update(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> searchCondition)
    {
        IQueryable<T> query = _entitie.Where(e => e.Active == true);
        return await query.AsNoTracking().Where(searchCondition).ToListAsync();
    }
}

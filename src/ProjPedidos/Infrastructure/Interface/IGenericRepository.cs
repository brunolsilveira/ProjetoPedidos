using System.Linq.Expressions;
using ProjPedidos.Application.Common.Models;

namespace ProjPedidos.Infrastructure.Interface;

public interface IGenericRepository<T> where T : BaseModel
{
    public Task AddAsync(T entity);
    public Task AddRangeAsync(IEnumerable<T> entities);
    public Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    public Task<bool> AnyAsync();
    public Task<int> CountAsync(Expression<Func<T, bool>> filter);
    public Task<int> CountAsync();
    public Task<T> GetByIdAsync(object id);
    public Task<Pagination<T>> GetAsync(Expression<Func<T, bool>> filter,
                                        int pageIndex = 0,
                                        int pageSize = 10,
                                        Expression<Func<T, object>>? orderBy = null,
                                        bool ascending = true);
    public Task<Pagination<TResult>> GetAsync<TResult>(Expression<Func<T, bool>> filter,
                                                       Expression<Func<T, TResult>> select,
                                                       int pageIndex = 0,
                                                       int pageSize = 10,
                                                       Expression<Func<T, object>>? orderBy = null,
                                                       bool ascending = true);
    public Task<Pagination<T>> ToPagination(int pageIndex,
                                            int pageSize,
                                            Expression<Func<T, object>>? orderBy = null,
                                            bool ascending = true);

    public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string[]? includes = null);
    public void Update(T entity);
    public void UpdateRange(IEnumerable<T> entities);
    public void Delete(T entity);
    public void DeleteRange(IEnumerable<T> entities);
    public Task Delete(object id);
}

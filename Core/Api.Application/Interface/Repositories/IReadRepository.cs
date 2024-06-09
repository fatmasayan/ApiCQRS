using Api.Domain.Comman;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Api.Application.Interface.Repositories;
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T> ,IIncludableQueryable<T, object>>? include=null,
            Func<IQueryable<T> , IOrderedQueryable<T>>? orderBy = null ,
            bool enableTracking = false
            );

        Task<List<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3
            );

        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false
            );

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate=null);
    }
    
}

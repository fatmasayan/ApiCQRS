using Api.Application.Interface.Repositories;
using Api.Domain.Comman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public ReadRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); } // her seferinde db context set etmemek için Table. yazarak işlem yapılır 

   
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table; //ne olaracağını belirtmediğimiz durumlarda kullanılır
            if (!enableTracking) queryable = queryable.AsNoTracking();//sorgu sonucu takip edilir update yapana kdr bu tracking mekanizması çalışır
            if (include != null) queryable= include(queryable);
            if(predicate is not null) queryable =  queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table; 
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage-1)*pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).ToListAsync();
            
        }

        //public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        //{
        //    IQueryable<T> queryable = Table;
        //    if (!enableTracking) queryable = queryable.AsNoTracking();
        //    if (include != null) queryable = include(queryable);
            
        //    //queryable.Where(predicate);
           
        //    return await queryable.FirstOrDefaultAsync(predicate);
        //}

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            return await queryable.Where(predicate).ToListAsync();
            //    return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate == null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking=false)
        {
            if(!enableTracking) Table.AsNoTracking();

            return  Table.Where(predicate);
        }
    }
}

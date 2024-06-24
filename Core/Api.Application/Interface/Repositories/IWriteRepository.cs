using Api.Domain.Comman;

namespace Api.Application.Interface.Repositories;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    // Save işlemi yaptıktan sonra save işlemi 1 den küçük olma durumuna göre başarılı oluşunu anlayabililirim.
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);

    Task<T> UpdateAsync(T entity);
    Task HardDeleteAsync(T entity);


}

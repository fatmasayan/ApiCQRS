using Api.Application.Interface.Repositories;
using Api.Domain.Comman;

namespace Api.Application.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new(); //new() : bir örneği nesnesi class'ı oluşturulabilir demek
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync(); //asenkron işlemlerde save işlemi yapmak için
        int Save();


    }
}

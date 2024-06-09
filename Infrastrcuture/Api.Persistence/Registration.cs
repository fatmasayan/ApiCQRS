using Api.Application.Interface.Repositories;
using Api.Persistence.Context;
using Api.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Persistence
{
    public static class Registration //configurasyon için 
    {
        //persistence ıservice collectiona ek olarak çalışan bir yapı ısevicecollestion.addpersistence şeklinde kullanılır
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        } 


    }
}

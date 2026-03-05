using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Infrastructure.Persistences.Repositories;

namespace POS.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(POSContext).Assembly.FullName;

            services.AddDbContext<POSContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("POSConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient );

            services.AddTransient<IUnitOfWork, UnitOfWork>();
<<<<<<< HEAD
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
=======
>>>>>>> 6d20b31533ce8f586b93660028abbb8bd68570ec

            return services;
        }
    }
}

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.Repository.Data;

namespace MVC.Repository
{
    public static class RepositoryExt
    {
        public static void AddRepositoryExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                        configure =>
                        {
                            configure.MigrationsAssembly(Assembly.GetAssembly(typeof(AssemblyRepository))!.FullName);
                        })
                    .AddInterceptors(new AppDbContextSaveChangesInterceptor());
            });
        }
    }
}
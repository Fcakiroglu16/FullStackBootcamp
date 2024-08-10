using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVC.Repository.Data;
using MVC.Repository.Identities;
using MVC.Repository.Products;

namespace MVC.Repository
{
    public static class RepositoryExt
    {
        public static void AddRepositoryExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

                options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                        configure =>
                        {
                            configure.MigrationsAssembly(Assembly.GetAssembly(typeof(AssemblyRepository))!.FullName);
                        })
                    .AddInterceptors(new AppDbContextSaveChangesInterceptor(httpContextAccessor));
            });


            // Add Identity
        }
    }
}
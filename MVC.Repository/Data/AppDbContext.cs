using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Repository.Identities;
using MVC.Repository.Products;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using MVC.Repository.Categories;

namespace MVC.Repository.Data
{
    public class AppDbContext
        : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor? contextAccessor) :
            base(options)
        {
            _contextAccessor = contextAccessor;


            if (contextAccessor is null) return;


            if (contextAccessor.HttpContext is null) return;


            if (contextAccessor.HttpContext!.User.IsUserAuthenticated())
            {
                UserId = Guid.Parse(
                    contextAccessor!.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!
                        .Value);
            }
        }

        private readonly IHttpContextAccessor? _contextAccessor;
        public Guid? UserId { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProductGlobalFilter(modelBuilder);


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ProductGlobalFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.UserId == UserId);
        }
    }
}
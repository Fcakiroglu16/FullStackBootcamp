using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Repository.Identities;
using MVC.Repository.Products;
using System.Reflection;

namespace MVC.Repository.Data
{
    public class AppDbContext
        : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    var entityEntries = ChangeTracker.Entries().ToList();

        //    foreach (var entityEntry in entityEntries)
        //    {
        //        if (entityEntry.Entity is IAuditByDate entity)
        //        {
        //            switch (entityEntry.State)
        //            {
        //                case EntityState.Added:
        //                    entity.Created = DateTime.Now;
        //                    Entry(entity).Property(x => x.Updated).IsModified = false;
        //                    break;

        //                case EntityState.Modified:
        //                    entity.Updated = DateTime.Now;
        //                    Entry(entity).Property(x => x.Created).IsModified = false;
        //                    break;
        //            }
        //        }
        //    }


        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MVC.Repository.Configurations;
using MVC.Repository.Products;

namespace MVC.Repository.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
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
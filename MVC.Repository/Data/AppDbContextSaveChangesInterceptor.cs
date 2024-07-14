using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MVC.Repository.Data
{
    public class AppDbContextSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var entityEntries = eventData.Context!.ChangeTracker.Entries().ToList();

            foreach (var entityEntry in entityEntries)
            {
                if (entityEntry.Entity is not IAuditByDate entity)
                {
                    continue;
                }

                switch (entityEntry.State)
                {
                    case EntityState.Added:

                        entity.Created = DateTime.Now;
                        eventData.Context.Entry(entity).Property(x => x.Updated).IsModified = false;
                        break;

                    case EntityState.Modified:


                        entity.Updated = DateTime.Now;
                        eventData.Context.Entry(entity).Property(x => x.Created).IsModified = false;
                        break;
                }
            }


            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
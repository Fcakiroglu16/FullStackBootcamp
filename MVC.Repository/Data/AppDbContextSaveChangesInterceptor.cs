using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.JsonWebTokens;
using MVC.Repository.Identities;
using MVC.Repository.Products;

namespace MVC.Repository.Data
{
    public class AppDbContextSaveChangesInterceptor(IHttpContextAccessor? contextAccessor) : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContextEventData, object, Guid?>>
            SaveChangeMethods = new();

        static AppDbContextSaveChangesInterceptor()
        {
            SaveChangeMethods.Add(EntityState.Added, AddBehavior);
            SaveChangeMethods.Add(EntityState.Modified, UpdateBehavior);
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var userId = contextAccessor.GetUserId();

            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                #region bad way

                //if (entityEntry.Entity is BaseUserEntity<Guid> baseUserEntity && userId.HasValue)
                //{
                //    baseUserEntity.UserId = userId.Value;
                //}

                //if (entityEntry.Entity is BaseUserEntity<int> baseUserEntity2 && userId.HasValue)
                //{
                //    baseUserEntity2.UserId = userId.Value;
                //}
                //if (userId.HasValue)
                //{
                //    var entityType = entityEntry.Entity.GetType();
                //    var userIdProperty = entityType.GetProperties().FirstOrDefault(p => p.Name == "UserId");

                //    if (userIdProperty is not null)
                //    {
                //        userIdProperty.SetValue(entityEntry.Entity, userId.Value);
                //    }
                //}

                #endregion

                if (entityEntry.State is not (EntityState.Added or EntityState.Modified)) continue;

                SaveChangeMethods[entityEntry.State](eventData, entityEntry.Entity, userId);


                var entityType = entityEntry.Entity.GetType();
                if (entityType.Name == "RefreshToken") continue;

                if (!userId.HasValue) continue;

                var userIdProperty = entityType.GetProperties().FirstOrDefault(p => p.Name == "UserId");


                if (userIdProperty is null) continue;
                userIdProperty.SetValue(entityEntry.Entity, userId.Value);


                #region Bad

                //switch (entityEntry.State)
                //{
                //    case EntityState.Added:

                //        AddBehavior(eventData, entity, userId);


                //        break;

                //    case EntityState.Modified:


                //        UpdateBehavior(eventData, entity, userId);


                //        break;
                //}

                #endregion
            }


            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        private static void UpdateBehavior(DbContextEventData eventData, object entity, Guid? userId)
        {
            if (entity is IAuditByDate entityAsDate)
            {
                entityAsDate.Updated = DateTime.Now;
                eventData.Context!.Entry(entityAsDate).Property(x => x.Created).IsModified = false;
            }

            if (userId.HasValue && entity is IAuditByUser entityAsUser)
            {
                entityAsUser.UpdatedByUser = userId;
                eventData.Context!.Entry(entityAsUser).Property(x => x.CreatedByUser).IsModified =
                    false;
            }
        }

        private static void AddBehavior(DbContextEventData eventData, object entity, Guid? userId)
        {
            if (entity is IAuditByDate entityAsDate)
            {
                entityAsDate.Created = DateTime.Now;
                eventData.Context!.Entry(entityAsDate).Property(x => x.Updated).IsModified = false;
            }


            if (userId.HasValue && entity is IAuditByUser entityAsUser)
            {
                entityAsUser.CreatedByUser = userId;
                eventData.Context!.Entry(entityAsUser).Property(x => x.UpdatedByUser).IsModified =
                    false;
            }
        }
    }
}
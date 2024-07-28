using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.JsonWebTokens;
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
            var userId = GetUserIdOrDefault();

            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                //var idProperty = entityEntry.Entity.GetType().GetProperty("Id");

                //var idPropertyPropertyType = idProperty!.PropertyType!;

                //TODO : refactoring
                if (entityEntry.Entity is BaseUserEntity<Guid> baseUserEntity && userId.HasValue)
                {
                    baseUserEntity.UserId = userId.Value;
                }

                if (entityEntry.Entity is BaseUserEntity<int> baseUserEntity2 && userId.HasValue)
                {
                    baseUserEntity2.UserId = userId.Value;
                }


                if (entityEntry.State is not (EntityState.Added or EntityState.Modified)) continue;

                SaveChangeMethods[entityEntry.State](eventData, entityEntry.Entity, userId);

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

        private Guid? GetUserIdOrDefault()
        {
            var hasUser =
                contextAccessor!.HttpContext!.User.FindFirst(x => x.Type == JwtRegisteredClaimNames.Name) is not null;
            if (contextAccessor is null || !hasUser)
            {
                return Guid.Empty;
            }


            return Guid.Parse(contextAccessor!.HttpContext.User
                .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
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
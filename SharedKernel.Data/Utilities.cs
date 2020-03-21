using System;
using System.Data.Entity;
using System.Linq.Expressions;
using MvcSalesApp.SharedKernel.Enums;
using MvcSalesApp.SharedKernel.Interfaces;

namespace SharedKernel.Data
{
  public static class Utilities
  {
    public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(int id) {
      var item = Expression.Parameter(typeof(TEntity), "entity");
      var prop = Expression.Property(item, typeof(TEntity).Name + "Id");
      var value = Expression.Constant(id);
      var equal = Expression.Equal(prop, value);
      var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
      return lambda;
    }

    private static EntityState ConvertState(ObjectState state) {
      switch (state) {
        case ObjectState.Added:
          return EntityState.Added;

        case ObjectState.Modified:
          return EntityState.Modified;

        case ObjectState.Deleted:
          return EntityState.Deleted;

        default:
          return EntityState.Unchanged;
      }
    }

    public static void FixState(this DbContext context) {
      foreach (var entry in context.ChangeTracker.Entries<IStateObject>()) {
        IStateObject stateInfo = entry.Entity;
        entry.State = ConvertState(stateInfo.State);
      }
    }
  }
}
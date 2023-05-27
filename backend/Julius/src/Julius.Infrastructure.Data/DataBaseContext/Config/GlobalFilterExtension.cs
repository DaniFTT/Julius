using Julius.SharedKernel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Julius.Infrastructure.Data.DataBaseContext.Config;

public static class GlobalFilterExtension
{
    public static void AddGlobalQueryFilter(
        this IMutableEntityType entityData, Guid userId)
    {
        var methodToCall = typeof(GlobalFilterExtension)
                    .GetMethod(nameof(CreateFilterExpression),
                        BindingFlags.NonPublic | BindingFlags.Static)
                    !.MakeGenericMethod(entityData.ClrType);

        var filter = methodToCall.Invoke(null, new object[] { userId });
        entityData.SetQueryFilter((LambdaExpression)filter!);
        entityData.AddIndex(entityData.FindProperty("UserId")!);        
        entityData.AddIndex(entityData.FindProperty("IsDeleted")!);
    }


    private static LambdaExpression CreateFilterExpression<TEntity>(Guid userId)
        where TEntity : EntityBase
    {
        Expression<Func<TEntity, bool>> expression = entity =>
            !entity.IsDeleted && entity.UserId == userId;

        return expression;
    }
}

﻿using LC.Infrastructure.Database.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace LC.Infrastructure.Database.Extensions
{
    /// <summary> 軟刪除查詢過濾器 </summary>
    public static class SoftDeleteQueryFilter
    {
        /// <summary>
        /// 加入軟刪除查詢過濾器
        /// 參考 https://www.thereformedprogrammer.net/introducing-the-efcore-softdeleteservices-library-to-automate-soft-deletes/
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        public static void Apply(ModelBuilder builder, Type type)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                //other automated configurations left out
                if (type.IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
    }

    /// <summary>
    /// DbContext 擴充方法
    /// </summary>
    public static class SoftDeleteExtension
    {
        /// <summary>
        /// 加入軟刪除查詢過濾器
        /// 參考 https://www.thereformedprogrammer.net/introducing-the-efcore-softdeleteservices-library-to-automate-soft-deletes/
        /// </summary>
        /// <param name="entityData"></param>
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteExtension)?.GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, Array.Empty<object>());
            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.FindProperty(nameof(IDelete.IsDelete)));
        }

        /// <summary>
        /// 取得軟刪除查詢過濾器
        /// 參考 https://www.thereformedprogrammer.net/introducing-the-efcore-softdeleteservices-library-to-automate-soft-deletes/
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        private static Expression<Func<TEntity, bool>> GetSoftDeleteFilter<TEntity>() where TEntity : class, IDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDelete;
            return filter;
        }

        /// <summary>
        /// 取得所有資料(包含已刪除)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="dbSet"></param>
        /// <returns></returns>
        public static IQueryable<TModel> FindAllWithDelete<TModel>(this DbSet<TModel> dbSet) where TModel : class
        {
            return dbSet.IgnoreQueryFilters();
        }
    }
}

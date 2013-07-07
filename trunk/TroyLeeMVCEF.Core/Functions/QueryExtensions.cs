using System;
using System.Collections.Generic;
using System.Linq;

namespace TroyLeeMVCEF.Core.Functions
{
    using System.Data.Linq.SqlClient;
    using System.Linq.Expressions;

    public static class QueryExtensions
    {
        public static IQueryable<TEntity> LikeAny<TEntity>(
            this IQueryable<TEntity> query,
            Expression<Func<TEntity, string>> selector,
            IEnumerable<string> values)
        {
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (!values.Any())
            {
                return query;
            }
            var p = selector.Parameters.Single();
            var conditions = values.Select(v =>
                (Expression)Expression.Call(typeof(SqlMethods), "Like", null,
                    selector.Body, Expression.Constant("%" + v + "%")));
            var body = conditions.Aggregate(Expression.Or);
            return query.Where(Expression.Lambda<Func<TEntity, bool>>(body, p));
        }
    }
}

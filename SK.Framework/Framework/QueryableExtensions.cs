using System.Linq.Expressions;

namespace SK.Framework;

public static class QueryableExtensions
{
    /// <summary>
    /// Dynamically choose which field of a database table to sort on and by which direction
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="query"></param>
    /// <param name="field"></param>
    /// <param name="sortDirection">Either string.Empty (ascending sort) or "Descending" (descending sort)</param>
    /// <returns></returns>
    public static IOrderedQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> query, string field, string? sortDirection)
    {
        try
        {
            // Only accept string.Empty (order ascending) or "Descending"
            if (!(sortDirection == null || sortDirection.Equals("Descending")))
                return (IOrderedQueryable<TEntity>)query;

            if (sortDirection == null)
                sortDirection = string.Empty;

            Type entityType = typeof(TEntity);
            ParameterExpression entityParameter = Expression.Parameter(entityType, "x");
            string[] properties = field.Split(",");
            Expression? orderProperties = properties[0].Split('.').Aggregate((Expression)entityParameter, Expression.PropertyOrField);
            LambdaExpression orderByLambda = Expression.Lambda(orderProperties, entityParameter);
            MethodCallExpression orderExpression = Expression.Call(typeof(Queryable),
                $"OrderBy{sortDirection}",
                new Type[] { entityType, orderProperties!.Type },
                query.Expression,
                Expression.Quote(orderByLambda));

            if (properties.Length == 1)
                return (IOrderedQueryable<TEntity>)query.Provider.CreateQuery<TEntity>(orderExpression);

            IQueryable<TEntity> midQuery = query.Provider.CreateQuery<TEntity>(orderExpression);
            for (int i = 1; i < properties.Length; i++)
            {
                Expression? thenProperties = properties[i].Split('.').Aggregate((Expression)entityParameter, Expression.PropertyOrField);
                LambdaExpression thenByLambda = Expression.Lambda(thenProperties, entityParameter);
                MethodCallExpression thenExpression = Expression.Call(typeof(Queryable),
                $"ThenBy{sortDirection}",
                new Type[] { entityType, thenProperties!.Type },
                midQuery.Expression,
                Expression.Quote(thenByLambda));
                midQuery = midQuery.Provider.CreateQuery<TEntity>(thenExpression);
            }
            return (IOrderedQueryable<TEntity>)midQuery;
        }
        catch (Exception)
        {
            return (IOrderedQueryable<TEntity>)query;
        }
    }
}
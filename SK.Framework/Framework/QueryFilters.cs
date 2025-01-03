using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.FactoryClasses;
using Charcillaries.Data.HelperClasses;
using Charcillaries.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using System.Reflection;

namespace SK.Framework;

public interface IFilter<T>
{
    IQueryable<T> Filter(IQueryable<T> query, LinqMetaData? meta = null);
}

public interface IFilter
{
    IPredicate Filter();
}

public interface ISort<T>
{
    IOrderedQueryable<T> Sort(IQueryable<T> query);
}

/// <summary>
/// QuerySpec version of IFilter
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IFilter2<T> where T : IEntityCore
{
    EntityQuery<T> Filter(QueryFactory qf);
}

/// <summary>
/// QuerySpec version of ISort
/// </summary>
public interface ISort2
{
    ISortClause[] Sort();
}

public record SortField2(string Type, string Property, SortDirection2 Direction);

/// <summary>
/// All QuerySpec based Sorter need to use this
/// </summary>
public static class Sorter2
{
    static Type GetType(string className)
    {
        UserFields.Id.Ascending();
        Assembly asm = typeof(UserFields).Assembly; //put other types in the HelperClasses here. This needs to change every project.
        //This namespace must be changed every project.!!!!!
        return asm.GetType($"Charcillaries.Data.HelperClasses.{className}")!;
    }

    /// <summary>
    /// Produce ISortClause for QuerySpec based on SortField2 definition
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    public static ISortClause Sort(this SortField2 field)
    {
        /* Chat GPT
         * To invoke an extension method tied to a property using reflection, you need to follow these steps:
         * Find the static class that defines the extension method and get its type object.
         * Get the MethodInfo object of the extension method using the GetMethod method of the type object. You may need to specify the generic arguments and the parameter types if the method is overloaded or generic.
         * Get the PropertyInfo object of the property using the GetProperty method of the type object of the class that has the property.
         * Get the value of the property using the GetValue method of the PropertyInfo object.
         * Invoke the extension method using the Invoke method of the MethodInfo object. You need to pass the value of the property as the first argument, followed by any other arguments required by the method.
        */

        var sortClause = typeof(SD.LLBLGen.Pro.QuerySpec.SortClauseProducers);
        var sorter = sortClause.GetMethod(field.Direction.ToString(), [typeof(IEntityFieldCore)])!;

        var t = GetType(field.Type);
        var p = t.GetProperty(field.Property)!;
        var val = p.GetValue(p)!;

        var sort = (ISortClause)sorter.Invoke(null, [val])!;
        return sort;
    }
}

/// <summary>
/// Used for Query Spec
/// </summary>
public enum SortDirection2
{
    Ascending,
    Descending
}

public interface IPrefetch
{
    SD.LLBLGen.Pro.ORMSupportClasses.IPrefetchPath2 Get();
}

public class QueryCondition<T>
{
    public IFilter<T>? Filter { get; set; }

    public QueryCondition()
    {
    }

    public QueryCondition(IFilter<T> f)
    {
        Filter = f;
    }
}

public class SortedQueryCondition<T> : QueryCondition<T>
{
    public ISort<T> Sorter { get; set; }

    public SortedQueryCondition(IFilter<T> f, ISort<T> s) : base(f)
    {
        Sorter = s;
    }
}

public class QueryConditionWithPrefetch<T> : QueryCondition<T>
{
    public IPrefetch Prefetch { get; set; }

    public QueryConditionWithPrefetch(IFilter<T> f, IPrefetch p) : base(f)
    {
        Prefetch = p;
    }
}

public class PagingQueryConditionPrefetched<T> : QueryConditionWithPrefetch<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public PagingQueryConditionPrefetched(IFilter<T> f, IPrefetch p, int page, int pageSize) : base(f, p)
    {
        Page = page;
        PageSize = pageSize;
    }
}

public class SortedPagingQueryConditionPrefetched<T> : PagingQueryConditionPrefetched<T>
{
    public ISort<T> Sorter { get; set; }

    public SortedPagingQueryConditionPrefetched(IFilter<T> f, IPrefetch p, ISort<T> s, int page, int pageSize) : base(f, p, page, pageSize)
    {
        Sorter = s;
    }
}

public class PagingQueryCondition<T> : QueryCondition<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public PagingQueryCondition(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }

    public PagingQueryCondition(IFilter<T> f, int page, int pageSize) : base(f)
    {
        Page = page;
        PageSize = pageSize;
    }
}

public class SortedPagingQueryCondition<T> : PagingQueryCondition<T>
{
    public ISort<T> Sorter { get; set; }

    public SortedPagingQueryCondition(IFilter<T> f, ISort<T> s, int page, int pageSize) : base(f, page, pageSize)
    {
        Sorter = s;
    }
}

public static class QueryBuilder
{
    public static PagingSpec<T> Paging<T>(IQueryable<T> query, PagingQueryConditionPrefetched<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Prefetch == null)
            throw new ArgumentNullException($"{nameof(qi.Prefetch)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var total = query;
        var result = query.WithPath(qi.Prefetch.Get()).Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return new PagingSpec<T>
        {
            Count = total,
            Listing = result
        };
    }

    public static PagingSpec<T> Paging<T>(IQueryable<T> query, SortedPagingQueryConditionPrefetched<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Prefetch == null)
            throw new ArgumentNullException($"{nameof(qi.Prefetch)} cannot be null");

        if (qi.Sorter == null)
            throw new ArgumentNullException($"{nameof(qi.Sorter)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var sorted = qi.Sorter.Sort(query);

        var total = sorted;
        var result = sorted.WithPath(qi.Prefetch.Get()).Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return new PagingSpec<T>
        {
            Count = total,
            Listing = result
        };
    }

    public static PagingSpec<T> Paging<T>(IQueryable<T> query, PagingQueryCondition<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var total = query;
        var result = query.Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return new PagingSpec<T>
        {
            Count = total,
            Listing = result
        };
    }

    public static PagingSpec<T> Paging<T>(IQueryable<T> query, SortedPagingQueryCondition<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Sorter == null)
            throw new ArgumentNullException($"{nameof(qi.Sorter)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var sorted = qi.Sorter.Sort(query);

        var total = sorted;
        var result = sorted.Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return new PagingSpec<T>
        {
            Count = total,
            Listing = result
        };
    }

    public static (PagingSpec<T>, IQueryable<T>) ReportPaging<T>(IQueryable<T> query, SortedPagingQueryCondition<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Sorter == null)
            throw new ArgumentNullException($"{nameof(qi.Sorter)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var sorted = qi.Sorter.Sort(query);

        var total = sorted;
        var result = sorted.Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return (new PagingSpec<T>
        {
            Count = total,
            Listing = result
        }, total);
    }

    public static (PagingSpec<T>, IQueryable<T>) ReportPagingForView<T>(IQueryable<T> query, SortedPagingQueryCondition<T> qi, LinqMetaData? meta = null) //where T : CommonEntityBase
    {
        if (qi.Sorter == null)
            throw new ArgumentNullException($"{nameof(qi.Sorter)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var sorted = qi.Sorter.Sort(query);

        var total = sorted;
        var result = sorted.Take(qi.PageSize).Skip((qi.Page - 1) * qi.PageSize);

        return (new PagingSpec<T>
        {
            Count = total,
            Listing = result
        }, total);
    }

    public static ManySpec<T> Many<T>(IQueryable<T> query, QueryCondition<T> filter, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        var result = filter.Filter!.Filter(query, meta);

        return new ManySpec<T>
        {
            Listing = result
        };
    }

    public static ManySpec<T> Many<T>(IQueryable<T> query, SortedQueryCondition<T> qi, LinqMetaData? meta = null) where T : CommonEntityBase
    {
        if (qi.Sorter == null)
            throw new ArgumentNullException($"{nameof(qi.Sorter)} cannot be null");

        if (qi.Filter != null)
            query = qi.Filter.Filter(query, meta);

        var result = qi.Sorter.Sort(query);

        return new PagingSpec<T>
        {
            Listing = result
        };
    }
}

public class SingleSpec<T>
{
    public IQueryable<T>? One { get; set; }
}

public class ManySpec<T>
{
    public IQueryable<T> Listing { get; set; } = default!;
}

public class PagingSpec<T> : ManySpec<T>
{
    public IQueryable<T> Count { get; set; } = default!;
}
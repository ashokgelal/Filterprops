
using System;
using System.Linq.Expressions;

namespace FilterProps
{
    public interface IFilterExpression<T>
    {
        Expression<Func<T, bool>> ItsExpression { get; }
    }
}

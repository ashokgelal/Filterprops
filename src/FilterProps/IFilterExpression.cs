
using System;
using System.Linq.Expressions;

namespace FilterProps
{
    public interface IFilterExpression<T>
    {
        bool ItsDoAndFlag { get; }
        Expression<Func<T, bool>> ItsExpression { get; }
    }
}

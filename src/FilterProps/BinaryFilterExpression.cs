using System;
using System.Linq.Expressions;

namespace FilterProps
{
    public class BinaryFilterExpression<T> : IFilterExpression<T>
    {
        public BinaryFilterExpression(Expression<Func<T, bool>> expression)
        {
            ItsExpression = expression;
        }

        public Expression<Func<T, bool>> ItsExpression { get; private set; }
    }
}

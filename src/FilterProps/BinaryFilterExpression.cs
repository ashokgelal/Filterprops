using System;
using System.Linq.Expressions;

namespace FilterProps
{
    public class BinaryFilterExpression<T> : IFilterExpression<T>
    {
        public BinaryFilterExpression(Expression<Func<T, bool>> expression)
        {
            ItsExpression = expression;
            ItsDoAndFlag = true;
        }

        public bool ItsDoAndFlag { get; set; }

        public Expression<Func<T, bool>> ItsExpression { get; private set; }
    }
}

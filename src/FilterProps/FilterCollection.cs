using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FilterProps
{
    public class FilterCollection<T> : List<IFilterExpression<T>>
    {
        public Expression<Func<T, bool>> ItsExpression { get; private set; }

        public void Add(IEnumerable<IFilterExpression<T>> filters)
        {
            foreach (var filter in filters)
            {
                AddToCollection(filter);
            }
        }

        private void AddToCollection(IFilterExpression<T> expression)
        {
            if (ItsExpression == null)
                ItsExpression = PredicateBuilderExtension.True<T>();
            ItsExpression = ItsExpression.And(expression.ItsExpression);
            Add(expression);
        }

        public IEnumerable<T> ApplyFilter(IEnumerable<T> coll)
        {
            if (ItsExpression == null)
                return coll;
            var query = coll.AsQueryable();
            return query.Where(ItsExpression);
        }

        public void AddNewFilter(IFilterExpression<T> filter)
        {
            AddToCollection(filter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FilterProps
{
    public class FilterService<T>
    {
        private readonly FilterCollection<T> _filterCollection;

        public FilterService(FilterCollection<T> coll)
        {
            _filterCollection = coll;
        }

        public FilterService()
        {
            _filterCollection = new FilterCollection<T>();
        }

        public IEnumerable<T> Filter(IEnumerable<T> list)
        {
            return _filterCollection.ApplyFilter(list);
        }

        public IFilterExpression<T> AddBinaryFilter(Expression<Func<T, bool>> expression)
        {
            var filter = new BinaryFilterExpression<T>(expression);
            _filterCollection.AddNewFilter(filter);
            return filter;
        }

        public IFilterExpression<T> DoAndWith(Expression<Func<T, bool>> expression)
        {
            return AddBinaryFilter(expression);
        }

        public IFilterExpression<T> DoOrWith(Expression<Func<T, bool>> expression)
        {
            var filter = new BinaryFilterExpression<T>(expression) { ItsDoAndFlag = false };
            _filterCollection.AddNewFilter(filter);
            return filter;
        }
    }
}

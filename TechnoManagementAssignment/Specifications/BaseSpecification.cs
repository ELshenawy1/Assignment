﻿using System.Linq.Expressions;

namespace TechnoManagementAssignment.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        protected void ApplyPaging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }

        protected void AddIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderby)
        {
            OrderBy = orderby;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderbydesc)
        {
            OrderByDescending = orderbydesc;
        }

    }
}

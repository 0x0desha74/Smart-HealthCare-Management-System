using CareFlow.Data.Entities;
using System.Linq.Expressions;

namespace CareFlow.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; } = new();
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnabled { get; set; }

        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        protected void AddIncludes(Func<IQueryable<T>, IQueryable<T>> thenIncludeExpression)
        {
            Includes.Add(thenIncludeExpression);
        }

        public void ApplyPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginationEnabled = true;
        }

    }

}

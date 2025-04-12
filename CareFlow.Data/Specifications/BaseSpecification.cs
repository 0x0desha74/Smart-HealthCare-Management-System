using CareFlow.Data.Entities;
using System.Linq.Expressions;

namespace CareFlow.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; } = new();


        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        protected void AddIncludes(Func<IQueryable<T>, IQueryable<T>> thenIncludeExpression)
        {
            Includes.Add(thenIncludeExpression);
        }
    }

}

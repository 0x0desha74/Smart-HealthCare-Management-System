using System.Linq.Expressions;

namespace CareFlow.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; set; }
        List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; }
        int Take { get; set; }
        int Skip { get; set; }
        bool IsPaginationEnabled { get; set; }
    }
}
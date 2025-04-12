using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace CareFlow.Core.Specifications
{
    public static class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);


            query = spec.Includes.Aggregate( query, (current, include) => include(current));
            return query;

        }

    }
}



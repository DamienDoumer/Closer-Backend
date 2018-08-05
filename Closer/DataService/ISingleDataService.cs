using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Closer.DataService
{
    public interface ISingleDataService<T>
    {
        Task<IEnumerable<T>> PersonalizedQuery(Expression<Func<T, bool>> predicate);
        Task<bool> PersonalizedDeleteQuery(Expression<Func<T, bool>> predicate);
    }
}

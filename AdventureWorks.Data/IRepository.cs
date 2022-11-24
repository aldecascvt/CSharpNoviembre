using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeproperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeproperties=null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(T entity);
    }
}

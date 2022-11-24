using Adventureworks.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly AdventureWorksDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(AdventureWorksDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter !=null)
            {
                query = query.Where(filter);
            }
            if (includeproperties != null)
            {
                foreach (var includeProp in includeproperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeproperties != null)
            {
                foreach (var includeProp in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(T entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

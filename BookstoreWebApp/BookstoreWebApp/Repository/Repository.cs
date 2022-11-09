using BookstoreWebApp.Data;
using BookstoreWebApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookstoreWebApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public T Find(params object?[]? keyValues)
        {
            return _context.Set<T>().Find(keyValues);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null) query = query.Where(filter);

            if (includeProps != null)
            {
                foreach(var prop in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProps = null, bool tracked = true)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();
            query = query.Where(filter);

            if (includeProps != null)
            {
                foreach (var prop in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}

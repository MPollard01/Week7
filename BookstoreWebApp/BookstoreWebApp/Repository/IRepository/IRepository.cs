using System.Linq.Expressions;

namespace BookstoreWebApp.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProps = null);
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProps = null, bool tracked = true);
        T Find(params object?[]? keyValues);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

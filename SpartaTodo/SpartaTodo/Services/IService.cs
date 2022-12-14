using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SpartaTodo.Services
{
    public interface IService<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<T?> FindAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task RemoveAsync(T entity);
        EntityEntry<T> Update(T entity);
        bool Exists(int id);
        Task<int> SaveChangesAsync();
        Task<EntityEntry<T>> AddAsync(T entity);
    }
}

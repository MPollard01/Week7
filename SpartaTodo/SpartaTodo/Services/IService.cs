using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SpartaTodo.Services
{
    public interface IService<T> where T : class
    {
        Task<T?> GetAsync(int id);
        Task<T?> FindAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task RemoveAsync(T entity);
        Task<EntityEntry<T>> UpdateAsync(T entity);
        bool Exists(int id);

    }
}

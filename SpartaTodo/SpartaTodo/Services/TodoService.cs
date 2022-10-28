using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpartaTodo.Data;
using SpartaTodo.Models;

namespace SpartaTodo.Services
{
    public class TodoService : ITodoService
    {
        private readonly SpataTodoContext _context;

        public TodoService()
        {
            _context = new SpataTodoContext();
        }
        public TodoService(SpataTodoContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<EntityEntry<Todo>> UpdateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}

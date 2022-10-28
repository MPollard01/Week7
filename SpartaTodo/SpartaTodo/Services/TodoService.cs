using Microsoft.EntityFrameworkCore;
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

        public async Task<EntityEntry<Todo>> AddAsync(Todo entity) => await _context.Todos.AddAsync(entity);

        public bool Exists(int id) => _context.Todos.Any(e => e.Id == id);

        public async Task<Todo?> FindAsync(int id) => await _context.Todos.FindAsync(id);

        public async Task<IEnumerable<Todo>> GetAllAsync() => await _context.Todos.ToListAsync();

        public async Task<Todo?> GetAsync(int id) => await _context.Todos.FirstOrDefaultAsync(e => e.Id == id);

        public async Task RemoveAsync(Todo entity)
        {
            _context.Todos.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        
        public EntityEntry<Todo> Update(Todo entity) => _context.Update(entity);
    }
}

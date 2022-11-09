using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}

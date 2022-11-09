using BookstoreWebApp.Models;

namespace BookstoreWebApp.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}

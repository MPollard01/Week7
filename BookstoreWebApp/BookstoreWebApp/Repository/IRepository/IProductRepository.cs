using BookstoreWebApp.Models;

namespace BookstoreWebApp.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}

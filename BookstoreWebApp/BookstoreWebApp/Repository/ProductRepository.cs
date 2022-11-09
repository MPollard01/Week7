using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(Product product)
        {
            var p = _context.Products.Find(product.Id);
            if(p != null)
            {
                p.Title = product.Title;
                p.Description = product.Description;
                p.Category = product.Category;
                p.Price = product.Price;
                p.Price50 = product.Price50;
                p.Price100 = product.Price100;
                p.ISBN = product.ISBN;
                p.CoverTypeId = product.CoverTypeId;
                p.Author = product.Author;
                p.ListPrice = product.ListPrice;
                p.ImageURL ??= product.ImageURL;
            }
        }
    }
}

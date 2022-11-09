using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; set; }
        public IApplicationUserRepository ApplicationUser { get; set; }
        public IOrderDetailRepository OrderDetail { get; set; }
        public IOrderHeaderRepository OrderHeader { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            CoverType = new CoverTypeRepository(_context);
            Company = new CompanyRepository(_context);
            Product = new ProductRepository(_context);
            ShoppingCart = new ShoppingCartRepository(_context);
            ApplicationUser = new ApplicationUserRepository(_context);
            OrderDetail = new OrderDetailRepository(_context);
            OrderHeader = new OrderHeaderRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

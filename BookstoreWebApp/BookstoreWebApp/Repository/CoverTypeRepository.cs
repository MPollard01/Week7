using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        public CoverTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(CoverType coverType)
        {
            _context.CoverTypes.Add(coverType);
        }
    }
}

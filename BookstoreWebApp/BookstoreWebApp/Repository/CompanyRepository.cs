using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}

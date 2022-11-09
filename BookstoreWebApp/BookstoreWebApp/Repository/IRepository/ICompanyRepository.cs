using BookstoreWebApp.Models;

namespace BookstoreWebApp.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}

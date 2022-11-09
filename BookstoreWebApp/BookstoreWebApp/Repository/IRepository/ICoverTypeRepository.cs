using BookstoreWebApp.Models;

namespace BookstoreWebApp.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}

using BookstoreWebApp.Models;

namespace BookstoreWebApp.Repository.IRepository
{
	public interface IOrderDetailRepository : IRepository<OrderDetail>
	{
		void Update(OrderDetail orderDetail);
	}
}

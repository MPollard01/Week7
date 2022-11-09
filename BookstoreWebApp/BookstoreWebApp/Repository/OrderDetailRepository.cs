using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
		public OrderDetailRepository(ApplicationDbContext context) : base(context)
		{
		}

		public void Update(OrderDetail orderDetail)
		{
			_context.OrderDetails.Update(orderDetail);
		}
	}
}

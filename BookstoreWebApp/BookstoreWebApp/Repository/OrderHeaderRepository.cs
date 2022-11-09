using BookstoreWebApp.Data;
using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;

namespace BookstoreWebApp.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		public OrderHeaderRepository(ApplicationDbContext context) : base(context)
		{
		}

		public void Update(OrderHeader orderHeader)
		{
			_context.OrderHeaders.Update(orderHeader);
		}

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var order = _context.OrderHeaders.Find(id);
			if (order != null)
			{
                order.OrderStatus = orderStatus;
                order.PaymentStatus ??= paymentStatus;
            }
		}

        public void UpdateStripePaymentID(int id, string sessionId, string? paymentIntentId)
        {
            var order = _context.OrderHeaders.Find(id);
			order.PaymentDate = DateTime.Now;
			order.SessionId = sessionId;
			order.PaymentIntentId = paymentIntentId;
        }
    }
}

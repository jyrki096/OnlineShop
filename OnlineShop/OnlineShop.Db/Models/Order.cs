using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db.Models
{
	public class Order
	{
		public Guid Id { get; set; }
		public OrderStatus Status { get; set; }
		public string UserName { get; set; }

		[Precision(18,5)]
		public decimal Cost { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Number { get; set; }
		public DateTime DeliveryDate { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Comment { get; set; }
	}
}

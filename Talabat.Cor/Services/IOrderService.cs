using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites.Order_Aggregate;

namespace Talabat.Cor.Services
{
	public interface IOrderService
	{
		Task<Order?> CreateOrderAsync(string BuyurEmail, string BasketId, int DeliveryMethodId, Address ShippingSddress);
		Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string BuyerEmail);
		Task<Order> GetOrderBYIdForSpecificUserAsync(string BuyerEmail, int OrderId);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor;
using Talabat.Cor.Entites;
using Talabat.Cor.Entites.Order_Aggregate;
using Talabat.Cor.Repositories;
using Talabat.Cor.Services;

namespace Talabat.Service
{
	public class OrderService : IOrderService
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IUnitOfWork _unitOfWork;

		public OrderService(IBasketRepository basketRepository,IUnitOfWork unitOfWork)
        {
			_basketRepository = basketRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Order?> CreateOrderAsync(string BuyurEmail, string BasketId, int DeliveryMethodId, Address ShippingAddress)
		{
			var Basket = await _basketRepository.GetBasketAsync(BasketId);
			var OrderItems = new List<OrderItem>();
			if (Basket?.Items.Count > 0) 
			{
				foreach(var item in Basket.Items)
				{
					var Product =await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
					var ProductItemOrdered=new ProductItemOrdered(Product.Id,Product.Name,Product.PictureUrl);
					var OrderItem = new OrderItem(ProductItemOrdered, item.Quantity, Product.Price);
					OrderItems.Add(OrderItem);
				}
			}
			var SubTotal = OrderItems.Sum(item => item.Price * item.Quantity);


			var DeliveryMethod=await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(DeliveryMethodId);


			var Order=new Order(BuyurEmail,ShippingAddress,DeliveryMethod,OrderItems,SubTotal);
			await _unitOfWork.Repository<Order>().AddAsync(Order);

			var Result = await _unitOfWork.CompleteAsync();
			if(Result<=0)return null;
			return Order;
		}


		public Task<Order> GetOrderBYIdForSpecificUserAsync(string BuyerEmail, int OrderId)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string BuyerEmail)
		{
			throw new NotImplementedException();
		}
	}
}

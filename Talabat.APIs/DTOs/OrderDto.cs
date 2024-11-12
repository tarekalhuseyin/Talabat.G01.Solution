using System.ComponentModel.DataAnnotations;
using Talabat.Cor.Entites.Order_Aggregate;

namespace Talabat.APIs.DTOs
{
	public class OrderDto
	{
		[Required]
		public string BasketId { get; set; }
		[Required]
		public int  DeliveryMethod  { get; set; }
		[Required]
		public AddressDto ShippingAddress { get; set; }
	}
}

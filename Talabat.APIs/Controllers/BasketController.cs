using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Cor.Entites;
using Talabat.Cor.Repositories;

namespace Talabat.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : APIBaseController
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;

		public BasketController(IBasketRepository basketRepository , IMapper mapper)
        {
			_basketRepository = basketRepository;
			_mapper = mapper;
		}
        [HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetCustomerBasket(string BasketId)
		{
			var Basket =await _basketRepository.GetBasketAsync(BasketId);
			 return Basket is null ? new CustomerBasket(BasketId) : Basket;
		}
		[HttpPost]
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto customerBasket)
		{
			var MappedBasket=_mapper.Map<CustomerBasketDto,CustomerBasket>(customerBasket);
			var CreatedOrUpdateedBsket= await _basketRepository.UpdateBasketAsync(MappedBasket);
			if (CreatedOrUpdateedBsket is null) return  BadRequest(new ApiResponse(400));

			return Ok(CreatedOrUpdateedBsket);
		}
		[HttpDelete]
		//public async Task<ActionResult<bool>> DeleteBasket(string BasketId)
		//{
			//return await _basketRepository.DeleteBasketAsync(BasketId);
		//}
		public async Task<ActionResult<bool>>DeleteBasket(string BasketId)
		{
			return await _basketRepository.DeleteBasketAsync(BasketId);
		}
	}
}

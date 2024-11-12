using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Cor.Entites;
using Talabat.Cor.Repositories;

namespace Talabat.Repository
{
	public class BasketRepository : IBasketRepository
	{
		private readonly IDatabase _database;

		public BasketRepository(IConnectionMultiplexer redis)
        {
			_database  =redis.GetDatabase() ;
		}

        public async Task<bool> DeleteBasketAsync(string BasketId)
		{
			return await _database.KeyDeleteAsync(BasketId);
		}

		public Task<bool> DeleteBasketAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<CustomerBasket> GetBasketAsync(string BasketId)
		{
			var Basket= await _database.StringGetAsync(BasketId);
			//if (Basket.IsNull) return null;
			//else 
			//	var 
			return Basket.IsNull?null:JsonSerializer.Deserialize<CustomerBasket>(Basket);
		}

		public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket Basket)
		{
			var JsonBasket =JsonSerializer.Serialize(Basket);
			var CreateOrUpgdate=await _database.StringSetAsync(Basket.Id, JsonBasket,TimeSpan.FromDays(1));
			if (!CreateOrUpgdate) return null;
			return await GetBasketAsync(Basket.Id);
		}
	}
}

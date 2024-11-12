﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Cor.Repositories
{
	public interface IBasketRepository
	{
		Task<CustomerBasket?> GetBasketAsync(string BasketId);
		Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket Basket);
		Task<bool> DeleteBasketAsync(string BasketId);
	}
}

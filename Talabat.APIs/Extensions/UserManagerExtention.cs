﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Cor.Entites.Identity;

namespace Talabat.APIs.Extensions
{
	public static class UserManagerExtention
	{
		public static async Task<AppUser?> FindUserWithAddressAsync(this UserManager<AppUser>userManager,ClaimsPrincipal User)
		{
			var email= User.FindFirstValue(ClaimTypes.Email);
			var user = await userManager.Users.Include(U => U.Address).FirstOrDefaultAsync(U => U.Email == email);
			return user;
		}
	}
}

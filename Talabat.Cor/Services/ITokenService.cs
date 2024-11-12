using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites.Identity;

namespace Talabat.Cor.Services
{
	public interface ITokenService
	{
		Task <string> CreateTokenAsync (AppUser User, UserManager<AppUser> userManager);
	}
}

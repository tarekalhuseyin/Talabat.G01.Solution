using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Talabat.Cor.Entites.Identity;
using Talabat.Cor.Services;
using Talabat.Repository.Identity;
using Talabat.Service;

namespace Talabat.APIs.Extensions
{
	public static class IdentityServiceExtention
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection Services, IConfiguration configuration)
		{
			Services.AddScoped<ITokenService, TokenService>();
			Services.AddIdentity<AppUser, IdentityRole>()
			.AddEntityFrameworkStores<AppIdentityDbContext>();
			Services.AddAuthentication(Options=>
			{
				Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(Options =>
				{
				Options.TokenValidationParameters = new TokenValidationParameters()
				{

					
					ValidateIssuer = true,
					ValidIssuer= configuration["JWT:ValidIssuer"],
					ValidateAudience = true,
					ValidAudience= configuration["JWT:ValidAudience"],
				    ValidateLifetime = true,

					ValidateIssuerSigningKey = true,
					 IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
				};
				});
			return Services;
		}
	}
}

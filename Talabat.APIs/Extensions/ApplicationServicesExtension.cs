using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Cor;
using Talabat.Cor.Repositories;
using Talabat.Cor.Services;
using Talabat.Repository;
using Talabat.Service;

namespace Talabat.APIs.Extensions
{
	public static class ApplicationServicesExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection Services)  
		{
			Services.AddScoped(typeof( IBasketRepository),typeof( BasketRepository));
			 Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			 Services.AddAutoMapper(typeof(MappingProfiles));
			 Services.Configure<ApiBehaviorOptions>(Options =>
			{
				Options.InvalidModelStateResponseFactory = (actionContext) =>
				{
					var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
											 .SelectMany(P => P.Value.Errors)
											 .Select(E => E.ErrorMessage)
											 .ToArray();


					var ValidationErrorResponse = new ApiValidationErrorResponse()
					{
						Errors = errors
					};
					return new BadRequestObjectResult(ValidationErrorResponse);
				};
			});
			Services.AddScoped<IUnitOfWork, IUnitOfWork>();
			Services.AddScoped<IOrderService,OrderService>();

			 return Services;
		}
	}
}

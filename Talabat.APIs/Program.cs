using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Helpers;
using Talabat.APIs.MiddleWare;
using Talabat.Cor.Entites.Identity;
using Talabat.Cor.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Identity;

namespace Talabat.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<StoreContext>(Options =>
			{
				Options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
			});

			builder.Services.AddDbContext<AppIdentityDbContext>(Options =>
			{
				Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
			});

			builder.Services.AddSingleton<IConnectionMultiplexer>(Option=>
			{
				var connection = builder.Configuration.GetConnectionString("RedisConnection");
				return ConnectionMultiplexer.Connect(connection);
			});




			builder.Services.AddApplicationServices();

			builder.Services.AddIdentityService(builder.Configuration);
		

			var app = builder.Build();


			#region Update Database
			//StoreContext dbContext = new StoreContext();
			//await dbContext.Database.MigrateAsync();
					using var Scope =app.Services.CreateScope();
					var Services=Scope.ServiceProvider;
			var LoggerFactory=Services.GetRequiredService<ILoggerFactory>();
			try
			{
					
				var dbContext=Services.GetRequiredService<StoreContext>();
				await dbContext.Database.MigrateAsync();
				var IdentityDbContext=Services.GetRequiredService<AppIdentityDbContext>();
				await IdentityDbContext.Database.MigrateAsync();
				var UserManager=Services.GetRequiredService<UserManager<AppUser>>();

				await AppIdentityDbContextSeed.SeedUserAsync(UserManager);
				await StoreContextSeed.SeedAsync(dbContext);

			}
			catch (Exception ex) 
			{
				var Logger = LoggerFactory.CreateLogger<Program>();
				Logger.LogError(ex, "Error occured during apling the migration ");
			}


			#endregion


			#region Data seeding 


			#endregion

			// Configure the HTTP request pipeline.
			 
			if (app.Environment.IsDevelopment())
			{
				app.UseMiddleware<ExceptionMiddleWare>();
				app.UseSwaggerMiddlewares();
			}
			app.UseStatusCodePagesWithRedirects("/errors/{0}");
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}

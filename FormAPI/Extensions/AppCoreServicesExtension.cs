
using FormAPI.Infrastructure.Data;

namespace FormAPI.Extensions
{
	public static class AppCoreServicesExtension
	{
		public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services, IConfiguration config)
		{

			services.AddScoped(sp => new DataContext(new()
			{
				CosmosKey = config.GetSection("cosmosKey").Value,
				CosmosUrl = config.GetSection("cosmosUrl").Value,
				DatabaseName = config.GetSection("databaseName").Value

			}));
			services.AddScoped<ApplicationDataContext>();

			return services;
		}
	}
}

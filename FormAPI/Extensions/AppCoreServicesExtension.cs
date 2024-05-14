
using FormAPI.ApplicationCore.Services;
using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using Microsoft.Azure.Cosmos;

namespace FormAPI.Extensions
{
	public static class AppCoreServicesExtension
	{
		public static async Task<IServiceCollection> AddApplicationCoreServices(this IServiceCollection services, IConfiguration config)
		{
			/*
			services.AddSingleton(sp => new DataContext(new()
			{
				CosmosKey = config.GetSection("CosmosConfigurations:CosmosKey").Value,
				CosmosUrl = config.GetSection("CosmosConfigurations:CosmosUrl").Value,
				DatabaseName = config.GetSection("CosmosConfigurations:DatabaseName").Value

			}));

			services.AddSingleton(sp => DataContext.InitialiseDb(new()
			{
				CosmosKey = config.GetSection("CosmosConfigurations:CosmosKey").Value,
				CosmosUrl = config.GetSection("CosmosConfigurations:CosmosUrl").Value,
				DatabaseName = config.GetSection("CosmosConfigurations:DatabaseName").Value

			}));
			*/
			var CosmosKey = config.GetSection("CosmosConfigurations:CosmosKey").Value;
			var CosmosUrl = config.GetSection("CosmosConfigurations:CosmosUrl").Value;
			var DatabaseName = config.GetSection("CosmosConfigurations:DatabaseName").Value;
			var client = new CosmosClient(CosmosUrl, CosmosKey);
			var database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);

			services.AddSingleton(sp =>  database.Database);

			var context = await ApplicationDataContext.InitializeDataContext(database.Database);
			services.AddSingleton( sp => context);

			
			services.AddScoped<IAdminService, AdminService>();
			services.AddScoped<ICandidateService, CandidateService>();
			return services;
		}
	}
}

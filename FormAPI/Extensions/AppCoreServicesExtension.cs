
using FormAPI.ApplicationCore.Services;
using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;

namespace FormAPI.Extensions
{
	public static class AppCoreServicesExtension
	{
		public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped(sp => new DataContext(new()
			{
				CosmosKey = config.GetSection("CosmosConfigurations:CosmosKey").Value,
				CosmosUrl = config.GetSection("CosmosConfigurations:CosmosUrl").Value,
				DatabaseName = config.GetSection("CosmosConfigurations:DatabaseName").Value

			}));
			services.AddScoped<ApplicationDataContext>();
			services.AddScoped<IAdminService, AdminService>();
			services.AddScoped<ICandidateService, CandidateService>();
			return services;
		}
	}
}

using FormAPI.Models.Entities;
using Microsoft.Azure.Cosmos;

namespace FormAPI.Infrastructure.Data
{
	public class ApplicationDataContext
	{
		private readonly Database _db;
		public ApplicationDataContext(Database database)
		{
			_db = database;
		}

		public DbSet<CandidateForm> CandidateForms { get; set; }
		public DbSet<FormConfiguration> FormConfigurations { get; set; }
		public DbSet<CustomQuestion> CustomQuestions { get; set; }


		public static async Task<ApplicationDataContext> InitializeDataContext(Database database)
		{
			var appContext = new ApplicationDataContext(database);
			await appContext.InitializeAllFields();
			return appContext;
		}


		public async Task InitializeAllFields()
		{
			CandidateForms = await GetContainer<CandidateForm>(_db);
			FormConfigurations = await GetContainer<FormConfiguration>( _db);
			CustomQuestions = await GetContainer<CustomQuestion>(_db);
		}

		public async Task<DbSet<T>> GetContainer<T>(Database database) where T : class
		{
			var containerName = typeof(T).Name;
			Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/partitionKeyPath", 400);
			var item = new DbSet<T>();
			item.Container = container;
			return item;
		}

	}

}

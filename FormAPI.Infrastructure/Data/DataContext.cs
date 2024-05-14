using Microsoft.Azure.Cosmos;
using System.Diagnostics;

namespace FormAPI.Infrastructure.Data
{
	/// <summary>
	/// This class is the DataContext, it contains the base intitaliser for the Cosmos Database
	/// </summary>
	public class DataContext
	{
		private readonly string cosmosUrl;
		private readonly string cosmosKey;
		private readonly string databaseName;


		private readonly CosmosClient client;
		public Database Database;
		public DataContext(DbContextOptions options)
		{
			cosmosUrl = options.CosmosUrl;
			cosmosKey = options.CosmosKey;
			databaseName = options.DatabaseName;
			client = new CosmosClient(cosmosUrl, cosmosKey);

		}

		public static async Task<Database> InitialiseDb(DbContextOptions options)
		{
			var dataContext = new DataContext(options);
			Database database = await dataContext.InitialiseDb();
			return database;
		}

		public async Task<Database> InitialiseDb()
		{
			Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
			Database = database;
			return Database;
		}

		

		public void Dispose()
		{
			if (client != null)
			{
				client.Dispose();
			}
		}

	}

	/// <summary>
	/// This class contains the model that would be used to retrieve keys for the datacontext
	/// </summary>
	public class DbContextOptions()
	{
		public string CosmosUrl { get; set; }
		public string CosmosKey { get; set; }
		public string DatabaseName { get; set; }
	}

}

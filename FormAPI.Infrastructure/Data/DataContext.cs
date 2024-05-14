using Microsoft.Azure.Cosmos;

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
		public DataContext(DbContextOptions options)
		{
			cosmosUrl = options.CosmosUrl;
			cosmosKey = options.CosmosKey;
			databaseName = options.DatabaseName;

			client = new CosmosClient(cosmosUrl, cosmosKey);

		}

		public async Task<Database> InitialiseDb()
		{
			
			Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);

			return database;
		}

		public async Task<Container> GetContainer(string containerName)
		{
			var database = await InitialiseDb();

			Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/partitionKeyPath", 400);

			return container;

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

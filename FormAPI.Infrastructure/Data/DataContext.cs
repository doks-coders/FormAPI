using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public DataContext(DbContextOptions options)
		{
			cosmosUrl = options.CosmosUrl;
			cosmosKey = options.CosmosKey;
			databaseName = options.DatabaseName;
		}

		public async Task<Database> InitialiseDb()
		{
			CosmosClient client = new CosmosClient(cosmosUrl, cosmosKey);

			Database database;
			try
			{
				database = client.GetDatabase(databaseName);

			}
			catch (Exception)
			{
				database = await client.CreateDatabaseIfNotExistsAsync(databaseName);

			}

			return database;
		}

		public async Task<Container> GetContainer(string containerName)
		{
			var database = await InitialiseDb();
	
			Container container = await database.CreateContainerIfNotExistsAsync(containerName, "/partitionKeyPath", 400);

			return container;

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

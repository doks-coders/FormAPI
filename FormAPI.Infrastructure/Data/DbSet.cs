using FormAPI.Models.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Infrastructure.Data
{
	public class DbSet<T> where T : class
	{
		private readonly DataContext _db;
		private readonly Database _database;
		public DbSet(DataContext db)
		{
			_db = db;
		}


		public async Task<T> GetItem(string id)
		{
			var containerName = typeof(T).Name;
			var items = await GetAllItems($"SELECT * FROM {containerName} f WHERE f.id=\"{id}\"");
			return items.FirstOrDefault();
		}

		public async Task<List<T>> GetAllItems(string? query = "SELECT * FROM c")
		{
			var containerName = typeof(T).Name;
			var container = await _db.GetContainer(containerName);
			var queryDefinition = new QueryDefinition(query);
			var items = new List<T>();
			try
			{
				using (var iterator = container.GetItemQueryIterator<T>(queryDefinition))
				{
					while (iterator.HasMoreResults)
					{
						FeedResponse<T> response = await iterator.ReadNextAsync();
						items.AddRange(response);
					}
				}
			}
			catch (CosmosException ex)
			{
			}

			return items;
		}


		public async Task<bool> UpsertItem(T Entity)
		{

			var baseObject = Entity as BaseEntity;
			var partitionKeyValue = baseObject.partitionKeyPath;


			var containerName = typeof(T).Name;
			var container = await _db.GetContainer(containerName);

			var partitionKey = new PartitionKey(partitionKeyValue);
			ItemResponse<T> item;
			try
			{
				item = await container.UpsertItemAsync<T>(Entity, partitionKey);
				return true;
			}
			catch (CosmosException ex)
			{
				Console.WriteLine("Error updating item: {0}", ex.Message);
				return false;
			}
		}



	}

}

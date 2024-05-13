using FormAPI.Models.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		public async Task<List<T>> GetItemCategory(string categoryId)
		{
			var containerName = typeof(T).Name;
			var items = await GetAllItems($"SELECT * FROM {containerName} f WHERE f.FormConfigId=\"{categoryId}\"");
			return items;
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

		public async Task<bool> DeleteOneItem(string id)
		{
			var containerName = typeof(T).Name;
			var container = await _db.GetContainer(containerName);

			var Entity = await GetItem(id);
			if (Entity == null) throw new Exception("Item to be deleted not found");
			var baseObject = Entity as BaseEntity;
			var partitionKeyValue = baseObject.partitionKeyPath;
			PartitionKey partitionKey = new PartitionKey(partitionKeyValue);
			
			try
			{
				await container.DeleteItemAsync<dynamic>(baseObject.id, partitionKey);
				Console.WriteLine("Item deleted successfully!");

				return true;
			}
			catch (CosmosException ex)
			{
				Console.WriteLine("Error deleting item: {0}", ex.Message);
				return false;
			}
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
